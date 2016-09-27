using Anchi.ERP.Domain.Finances;
using Anchi.ERP.Domain.Finances.Enum;
using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.Products.Enum;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Domain.RepairOrders.Enum;
using Anchi.ERP.Domain.Sequences.Enum;
using Anchi.ERP.IRepository.Repairs;
using Anchi.ERP.Repository.Customers;
using Anchi.ERP.Repository.Employees;
using Anchi.ERP.Repository.Products;
using Anchi.ERP.Repository.Sequences;
using ServiceStack.OrmLite;
using System;

namespace Anchi.ERP.Repository.Repairs
{
    /// <summary>
    /// 维修单仓储层
    /// </summary>
    public class RepairOrderRepository : BaseRepository<RepairOrder>, IRepairOrderRepository
    {
        #region 构造函数和属性
        public RepairOrderRepository()
            : this(new RepairOrderProjectRepository(),
                  new RepairOrderProductRepository(),
                  new CustomerRepository(),
                  new EmployeeRepository(),
                  new ProductStockRecordRepository())
        {
        }

        public RepairOrderRepository(RepairOrderProjectRepository repairOrderProjectRepository,
                                    RepairOrderProductRepository repairOrderProductRepository,
                                    CustomerRepository customerRepository,
                                    EmployeeRepository employeeRepository,
                                    ProductStockRecordRepository productStockRecordRepository)
        {
            this.RepairOrderProjectRepository = repairOrderProjectRepository;
            this.RepairOrderProductRepository = repairOrderProductRepository;
            this.CustomerRepository = customerRepository;
            this.EmployeeRepository = employeeRepository;
            this.ProductStockRecordRepository = productStockRecordRepository;
        }

        RepairOrderProjectRepository RepairOrderProjectRepository
        {
            get;
        }
        RepairOrderProductRepository RepairOrderProductRepository
        {
            get;
        }
        CustomerRepository CustomerRepository
        {
            get;
        }
        EmployeeRepository EmployeeRepository
        {
            get;
        }
        ProductStockRecordRepository ProductStockRecordRepository
        {
            get;
        }
        #endregion

        #region 创建维修单
        /// <summary>
        /// 创建维修单
        /// </summary>
        /// <param name="model"></param>
        public override void Create(RepairOrder model)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    // 插入维修单
                    model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                    model.Code = string.IsNullOrWhiteSpace(model.Code) ? GetSequenceNextCode() : model.Code;
                    model.CreatedOn = DateTime.Now;
                    context.Insert(model);

                    // 插入维修项目
                    foreach (var item in model.ProjectList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        context.Insert(item);
                    }

                    // 插入使用配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        context.Insert(item);
                    }
                    tran.Commit();
                }
            }
        }
        #endregion

        #region 获取维修单
        /// <summary>
        /// 获取维修单，并填充关联数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override RepairOrder GetModel(Guid Id)
        {
            using (var context = DbContext.Open())
            {
                var model = context.SingleById<RepairOrder>(Id);
                if (model == null)
                    return null;

                model.ProjectList = RepairOrderProjectRepository.Find(model.Id);
                model.ProductList = RepairOrderProductRepository.Find(model.Id);
                model.Customer = CustomerRepository.Get(model.CustomerId);
                model.ReceptionBy = EmployeeRepository.Get(model.ReceptionById);

                return model;
            }
        }
        #endregion

        #region 修改维修单
        /// <summary>
        /// 修改维修单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override void UpdateModel(RepairOrder model)
        {
            if (model == null || model.Id == Guid.Empty)
                return;

            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    // 修改维修单
                    context.Update(model);

                    // 删除历史维修项目
                    context.Delete<RepairOrderProject>(item => item.RepairOrderId == model.Id);
                    // 删除历史配件明细
                    context.Delete<RepairOrderProduct>(item => item.RepairOrderId == model.Id);

                    // 插入新的维修项目
                    foreach (var item in model.ProjectList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        context.Insert(item);
                    }
                    // 插入新的配件明细
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        context.Insert(item);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 设置已完工
        /// <summary>
        /// 设置已完工
        /// </summary>
        /// <param name="model"></param>
        public void Complete(RepairOrder model)
        {
            if (model == null || model.Id == Guid.Empty)
                return;

            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    // 修改维修单状态
                    model.Status = EnumRepairOrderStatus.Completed;
                    model.CompleteOn = DateTime.Now;
                    context.Update(model);

                    // 扣配件库存，并增加出库记录
                    foreach (var item in model.ProductList)
                    {
                        var product = context.SingleById<Product>(item.ProductId);
                        if (product == null)
                            throw new Exception(string.Format("获取配件信息失败，配件ID：{0}", item.ProductId));

                        // 插入配件出库记录
                        var record = new ProductStockRecord
                        {
                            Id = Guid.NewGuid(),
                            RelationId = model.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Type = EnumStockRecordType.Repair,
                            QuantityBefore = product.Stock,
                            CreatedOn = DateTime.Now,
                            RecordOn = model.CompleteOn,
                            Remark = string.Format("维修单：{0} 完工", model.Code),
                        };
                        context.Insert(record);

                        // 扣该配件的库存
                        product.Stock = product.Stock - item.Quantity;
                        context.Update(product);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 取消维修单
        /// <summary>
        /// 取消算维修单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="order"></param>
        public void Cancel(RepairOrder model, FinanceOrder order)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    #region 调整库存
                    foreach (var item in model.ProductList)
                    {
                        var product = item.Product;
                        if (product == null)
                            continue;

                        if (model.Status == EnumRepairOrderStatus.Completed)
                        {   // 如果是已完工的维修单，需要回滚配件库存
                            // 插入配件出入库记录
                            var record = new ProductStockRecord
                            {
                                Id = Guid.NewGuid(),
                                CreatedOn = DateTime.Now,
                                ProductId = product.Id,
                                Quantity = item.Quantity,
                                QuantityBefore = product.Stock,
                                RecordOn = DateTime.Now,
                                RelationId = model.Id,
                                Type = EnumStockRecordType.CancelRepair,
                                Remark = string.Format("取消维修单：{0}", model.Code),
                            };
                            context.Insert(record);

                            // 加回配件库存
                            product.Stock = product.Stock + item.Quantity;
                            context.Update(product);
                        }
                    }
                    #endregion

                    #region 增加财务单
                    if (model.SettlementAmount > 0)
                    {   // 如果是结算过的维修单，增加相应的财务单
                        order.Id = Guid.NewGuid();
                        order.Amount = model.SettlementAmount;
                        order.Type = EnumFinanceOrderType.CancelRepair;
                        order.CreatedOn = DateTime.Now;
                        order.RelationId = model.Id;
                        order.Remark = string.Format("取消维修单：{0}", model.Code);
                        context.Insert(order);
                    }
                    #endregion

                    // 删除维修单配件
                    context.Delete<RepairOrderProduct>(rop => rop.RepairOrderId == model.Id);

                    // 删除维修单
                    context.Delete<RepairOrder>(ro => ro.Id == model.Id);

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 结算维修单
        /// <summary>
        /// 结算维修单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="order"></param>
        public void Settlement(RepairOrder model, FinanceOrder order)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.OpenTransaction())
                {
                    // 修改维修单
                    model.SettlementOn = DateTime.Now;
                    context.Update(model);

                    // 新增财务单
                    order.Id = order.Id == Guid.Empty ? Guid.NewGuid() : order.Id;
                    order.RelationId = model.Id;
                    order.CreatedOn = model.SettlementOn;
                    order.Type = EnumFinanceOrderType.Repair;
                    order.Remark = string.Format("结算维修单：{0}", model.Code);
                    context.Insert(order);

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 生成维修单编码
        /// <summary>
        /// 生成维修单编码
        /// </summary>
        /// <returns></returns>
        public string GetSequenceNextCode()
        {
            return string.Format("RO-{0}{1}", DateTime.Now.ToString("yyyyMMdd"), SequenceRepository.Instance.GetNextValue(EnumSequenceType.Repair).ToString("0000"));
        }
        #endregion
    }
}
