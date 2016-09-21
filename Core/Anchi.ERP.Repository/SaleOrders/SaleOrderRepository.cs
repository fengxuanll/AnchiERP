using Anchi.ERP.Domain.Finances;
using Anchi.ERP.Domain.Finances.Enum;
using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.Products.Enum;
using Anchi.ERP.Domain.SaleOrders;
using Anchi.ERP.Domain.SaleOrders.Enum;
using Anchi.ERP.IRepository.SaleOrders;
using Anchi.ERP.Repository.Customers;
using Anchi.ERP.Repository.Employees;
using Anchi.ERP.Repository.Products;
using ServiceStack.OrmLite;
using System;

namespace Anchi.ERP.Repository.SaleOrders
{
    /// <summary>
    /// 销售单仓储类
    /// </summary>
    public class SaleOrderRepository : BaseRepository<SaleOrder>, ISaleOrderRepository
    {
        #region 构造函数和属性
        public SaleOrderRepository()
            : this(new SaleOrderProductRepository(),
                  new EmployeeRepository(),
                  new CustomerRepository(),
                  new ProductStockRecordRepository(),
                  new ProductRepository())
        { }

        public SaleOrderRepository(
            SaleOrderProductRepository saleOrderProductRepository,
            EmployeeRepository employeeRepository,
            CustomerRepository customerRepository,
            ProductStockRecordRepository productStockRecordRepository,
            ProductRepository productRepository)
        {
            this.SaleOrderProductRepository = saleOrderProductRepository;
            this.EmployeeRepository = employeeRepository;
            this.CustomerRepository = customerRepository;
            this.ProductStockRecordRepository = productStockRecordRepository;
            this.ProductRepository = productRepository;
        }

        SaleOrderProductRepository SaleOrderProductRepository { get; }
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
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    // 插入销售单
                    model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                    model.CreatedOn = DateTime.Now;
                    context.Insert(model);

                    // 插入销售配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.SaleOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        context.Insert(item);
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
        public override void UpdateModel(SaleOrder model)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    // 更新销售单
                    context.Update(model);

                    // 删除历史销售配件
                    context.Delete<SaleOrderProduct>(item => item.SaleOrderId == model.Id);

                    // 插入新的销售配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.SaleOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        context.Insert(item);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 获取销售单
        /// <summary>
        /// 获取销售单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override SaleOrder GetModel(Guid Id)
        {
            using (var context = DbContext.Open())
            {
                var model = context.SingleById<SaleOrder>(Id);
                if (model == null)
                    return null;

                model.SaleBy = EmployeeRepository.GetModel(model.SaleById);
                model.Customer = CustomerRepository.GetModel(model.CustomerId);
                model.ProductList = SaleOrderProductRepository.Find(model.Id);

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
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    // 修改状态为已出库
                    model.Status = EnumSaleOrderStatus.Outbound;
                    model.OutboundOn = DateTime.Now;
                    context.Update(model);

                    // 扣产品库存
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
                            Type = EnumStockRecordType.Sale,
                            QuantityBefore = product.Stock,
                            CreatedOn = DateTime.Now,
                            RecordOn = model.OutboundOn,
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

        #region 取消销售单
        /// <summary>
        /// 取消销售单
        /// </summary>
        /// <param name="model"></param>
        public void Cancel(SaleOrder model)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    foreach (var item in model.ProductList)
                    {
                        var product = item.Product;
                        if (product == null)
                            continue;

                        if (model.Status == EnumSaleOrderStatus.Outbound)
                        {   // 如果是已出库的销售单，需要回滚配件库存
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
                                Type = EnumStockRecordType.CancelSale,
                            };
                            context.Insert(record);

                            // 加回配件库存
                            product.Stock = product.Stock + item.Quantity;
                            context.Update(product);
                        }
                    }

                    // 删除销售单配件
                    context.Delete<SaleOrderProduct>(rop => rop.SaleOrderId == model.Id);

                    // 删除采购单
                    context.Delete<SaleOrder>(ro => ro.Id == model.Id);

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 结算销售单
        /// <summary>
        /// 结算销售单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="order"></param>
        public void Settlement(SaleOrder model, FinanceOrder order)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.OpenTransaction())
                {
                    // 修改销售单
                    model.SettlementOn = DateTime.Now;
                    context.Update(model);

                    // 新增财务单
                    order.Id = order.Id == Guid.Empty ? Guid.NewGuid() : order.Id;
                    order.RelationId = model.Id;
                    order.CreatedOn = model.SettlementOn;
                    order.Type = EnumFinanceOrderType.ReceiptSale;
                    context.Insert(order);

                    tran.Commit();
                }
            }
        }
        #endregion
    }
}
