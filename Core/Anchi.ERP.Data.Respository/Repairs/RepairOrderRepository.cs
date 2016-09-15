using Anchi.ERP.Data.Repository.Customers;
using Anchi.ERP.Data.Repository.Employees;
using Anchi.ERP.Data.Repository.ProductStocks;
using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.Products.Enum;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Domain.RepairOrder.Enum;
using SqliteSugar;
using System;

namespace Anchi.ERP.Data.Repository.Repairs
{
    /// <summary>
    /// 维修单仓储层
    /// </summary>
    public class RepairOrderRepository : BaseRepository<RepairOrder>
    {
        #region 构造函数和属性
        public RepairOrderRepository()
            : this(new RepairOrderProjectRepository(),
                  new RepairOrderProductRepository(),
                  new CustomerRepository(),
                  new EmployeeRepository(),
                  new ProductStockRecordRepository())
        { }

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

        RepairOrderProjectRepository RepairOrderProjectRepository { get; }
        RepairOrderProductRepository RepairOrderProductRepository { get; }
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
            using (var context = new AnchiDbContext())
            {
                context.BeginTran();

                // 插入维修单
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
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

                context.CommitTran();
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
            using (var context = new AnchiDbContext())
            {
                var model = context.Queryable<RepairOrder>().Where(item => item.Id == Id).FirstOrDefault();
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

            using (var context = new AnchiDbContext())
            {
                context.BeginTran();

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

                context.CommitTran();
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

            using (var context = new AnchiDbContext())
            {
                context.BeginTran();

                // 修改维修单状态
                model.Status = EnumRepairOrderStatus.Completed;
                model.CompleteOn = DateTime.Now;
                context.Update(model);

                // 扣配件库存，并增加出库记录
                foreach (var item in model.ProductList)
                {
                    var product = context.Queryable<Product>().Where(p => p.Id == item.ProductId).FirstOrDefault();
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
                    };
                    context.Insert(record);

                    // 扣该配件的库存
                    product.Stock = product.Stock - item.Quantity;
                    context.Update(product);
                }

                context.CommitTran();
            }
        }
        #endregion
    }
}
