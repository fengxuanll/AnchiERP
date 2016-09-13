using Anchi.ERP.Data.Customers;
using Anchi.ERP.Data.Employees;
using Anchi.ERP.Data.Products;
using Anchi.ERP.Data.ProductStocks;
using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.Products.Enum;
using Anchi.ERP.Domain.SaleOrders;
using Anchi.ERP.Domain.SaleOrders.Enum;
using ServiceStack.OrmLite;
using System;
using System.Linq;

namespace Anchi.ERP.Data.SaleOrders
{
    /// <summary>
    /// 销售单仓储类
    /// </summary>
    public class SaleOrderRepository : BaseRepository<SaleOrder>
    {
        #region 构造函数和属性
        public SaleOrderRepository()
            : this(new SaleProductItemRepository(),
                  new EmployeeRepository(),
                  new CustomerRepository(),
                  new ProductStockRecordRepository(),
                  new ProductRepository())
        { }

        public SaleOrderRepository(
            SaleProductItemRepository saleProductItemRepository,
            EmployeeRepository employeeRepository,
            CustomerRepository customerRepository,
            ProductStockRecordRepository productStockRecordRepository,
            ProductRepository productRepository)
        {
            this.SaleProductItemRepository = saleProductItemRepository;
            this.EmployeeRepository = employeeRepository;
            this.CustomerRepository = customerRepository;
            this.ProductStockRecordRepository = productStockRecordRepository;
            this.ProductRepository = productRepository;
        }

        SaleProductItemRepository SaleProductItemRepository { get; }
        EmployeeRepository EmployeeRepository { get; }
        CustomerRepository CustomerRepository { get; }
        ProductStockRecordRepository ProductStockRecordRepository { get; }
        ProductRepository ProductRepository { get; }
        #endregion

        #region 创建销售单
        /// <summary>
        /// 创建销售单
        /// </summary>
        /// <param name="model"></param>
        public override void Create(SaleOrder model)
        {
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    // 插入销售单
                    model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                    model.CreatedOn = DateTime.Now;
                    db.Insert(model);

                    // 插入销售配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.SaleOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 修改销售单
        /// <summary>
        /// 修改销售单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override int Update(SaleOrder model)
        {
            int rows = 0;
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    // 更新销售单
                    rows = db.Update(model);

                    // 删除历史销售配件
                    db.Delete<SaleProductItem>(item => item.SaleOrderId == model.Id);

                    // 插入新的销售配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.SaleOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }

                    tran.Commit();
                }
            }
            return rows;
        }
        #endregion

        #region 获取销售单
        /// <summary>
        /// 获取销售单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override SaleOrder GetById(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                var model = db.Single<SaleOrder>(Id);
                if (model == null)
                    return null;

                model.SaleBy = EmployeeRepository.GetModel(model.SaleById);
                model.Customer = CustomerRepository.GetModel(model.CustomerId);
                model.ProductList = SaleProductItemRepository.Find(model.Id);

                return model;
            }
        }
        #endregion

        #region 销售单出库
        /// <summary>
        /// 销售单出库
        /// </summary>
        /// <param name="model"></param>
        public void Outbound(SaleOrder model)
        {
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    // 修改状态为已出库
                    model.Status = EnumSaleOrderStatus.Outbound;
                    model.OutboundOn = DateTime.Now;
                    db.Update(model);

                    // 扣产品库存
                    foreach (var item in model.ProductList)
                    {
                        var product = ProductRepository.GetModel(item.ProductId);
                        if (product == null)
                            throw new Exception(string.Format("获取配件信息失败，配件ID：{0}", item.ProductId));

                        // 插入配件出库记录
                        var record = new ProductStockRecord
                        {
                            Id = Guid.NewGuid(),
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Type = EnumStockRecordType.Sale,
                            QuantityBefore = product.Stock,
                            CreatedOn = DateTime.Now,
                            RecordOn = model.OutboundOn,
                        };
                        db.Insert(record);

                        // 修改配件的已有库存
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
