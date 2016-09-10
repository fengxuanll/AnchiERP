using Anchi.ERP.Data.Customers;
using Anchi.ERP.Data.Employees;
using Anchi.ERP.Data.ProductStocks;
using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.Products.Enum;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Domain.RepairOrder.Enum;
using ServiceStack.OrmLite;
using System;

namespace Anchi.ERP.Data.Repairs
{
    /// <summary>
    /// 维修单仓储层
    /// </summary>
    public class RepairOrderRepository : BaseRepository<RepairOrder>
    {
        #region 构造函数和属性
        public RepairOrderRepository()
            : this(new RepairOrderItemRepository(),
                  new RepairProductItemRepository(),
                  new CustomerRepository(),
                  new EmployeeRepository(),
                  new ProductStockRecordRepository())
        { }

        public RepairOrderRepository(RepairOrderItemRepository repairOrderItemRepository,
                                    RepairProductItemRepository repairProductItemRepository,
                                    CustomerRepository customerRepository,
                                    EmployeeRepository employeeRepository,
                                    ProductStockRecordRepository productStockRecordRepository)
        {
            this.RepairOrderItemRepository = repairOrderItemRepository;
            this.RepairProductItemRepository = repairProductItemRepository;
            this.CustomerRepository = customerRepository;
            this.EmployeeRepository = employeeRepository;
            this.ProductStockRecordRepository = productStockRecordRepository;
        }

        RepairOrderItemRepository RepairOrderItemRepository { get; }

        RepairProductItemRepository RepairProductItemRepository { get; }

        CustomerRepository CustomerRepository { get; }

        EmployeeRepository EmployeeRepository { get; }

        ProductStockRecordRepository ProductStockRecordRepository { get; }
        #endregion

        #region 创建维修单
        /// <summary>
        /// 创建维修单
        /// </summary>
        /// <param name="model"></param>
        public override void Create(RepairOrder model)
        {
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    // 插入维修单
                    model.CreatedOn = DateTime.Now;
                    db.Insert(model);

                    // 插入维修项目
                    foreach (var item in model.ItemList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }

                    // 插入使用配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
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
        public override RepairOrder GetById(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                var model = db.SingleById<RepairOrder>(Id);
                if (model == null)
                    return null;

                model.ItemList = RepairOrderItemRepository.Find(Id);
                model.ProductList = RepairProductItemRepository.Find(Id);
                model.Customer = CustomerRepository.GetById(model.CustomerId);
                model.ReceptionBy = EmployeeRepository.GetById(model.ReceptionById);

                return model;
            }
        }
        #endregion

        #region 获取维修单
        /// <summary>
        /// 获取维修单，不填充关联数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RepairOrder GetModel(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                return db.SingleById<RepairOrder>(Id);
            }
        }
        #endregion

        #region 修改维修单
        /// <summary>
        /// 修改维修单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override int Update(RepairOrder model)
        {
            if (model == null || model.Id == Guid.Empty)
                return 0;

            var rows = 0;
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    rows = db.Update(model);

                    // 删除历史维修项目
                    db.Delete<RepairOrderItem>(item => item.RepairOrderId == model.Id);
                    // 删除历史配件明细
                    db.Delete<RepairProductItem>(item => item.RepairOrderId == model.Id);

                    // 插入新的维修项目
                    foreach (var item in model.ItemList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }
                    // 插入新的配件明细
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.RepairOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }

                    tran.Commit();
                }
            }
            return rows;
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

            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    // 修改维修单状态
                    model.Status = EnumRepairOrderStatus.Completed;
                    model.CompleteOn = DateTime.Now;
                    db.Update(model);

                    // 扣配件库存，并增加出库记录
                    foreach (var item in model.ProductList)
                    {
                        var product = db.SingleById<Product>(item.ProductId);
                        if (product == null)
                            throw new Exception(string.Format("获取配件信息失败，配件ID：{0}", item.ProductId));

                        // 插入配件出库记录
                        var record = new ProductStockRecord
                        {
                            Id = Guid.NewGuid(),
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Type = EnumStockRecordType.Repair,
                            QuantityBefore = product.Stock,
                            CreatedOn = model.CreatedOn,
                        };
                        db.Insert(record);

                        // 扣该配件的库存
                        product.Stock = product.Stock - item.Quantity;
                        db.Update(product);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion
    }
}
