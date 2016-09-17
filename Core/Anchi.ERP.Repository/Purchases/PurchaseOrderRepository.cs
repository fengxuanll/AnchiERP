using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.Products.Enum;
using Anchi.ERP.Domain.PurchaseOrders;
using Anchi.ERP.Domain.PurchaseOrders.Enum;
using Anchi.ERP.IRepository.Purchases;
using Anchi.ERP.Repository.Employees;
using Anchi.ERP.Repository.Products;
using Anchi.ERP.Repository.Suppliers;
using System;
using ServiceStack.OrmLite;

namespace Anchi.ERP.Repository.Purchases
{
    /// <summary>
    /// 采购仓储类
    /// </summary>
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>, IPurchaseOrderRepository
    {
        #region 构造函数和属性
        public PurchaseOrderRepository()
            : this(new PurchaseOrderProductRepository(),
                  new EmployeeRepository(),
                  new SupplierRepository(),
                  new ProductStockRecordRepository(),
                  new ProductRepository())
        { }

        public PurchaseOrderRepository(
            PurchaseOrderProductRepository purchaseOrderProductRepository,
            EmployeeRepository employeeRepository,
            SupplierRepository supplierRepository,
            ProductStockRecordRepository productStockRecordRepository,
            ProductRepository productRepository)
        {
            this.PurchaseOrderProductRepository = purchaseOrderProductRepository;
            this.EmployeeRepository = employeeRepository;
            this.SupplierRepository = supplierRepository;
            this.ProductStockRecordRepository = productStockRecordRepository;
            this.ProductRepository = productRepository;
        }

        ProductRepository ProductRepository { get; }
        PurchaseOrderProductRepository PurchaseOrderProductRepository { get; }
        EmployeeRepository EmployeeRepository { get; }
        SupplierRepository SupplierRepository { get; }
        ProductStockRecordRepository ProductStockRecordRepository { get; }
        #endregion

        #region 创建采购单
        /// <summary>
        /// 创建采购单
        /// </summary>
        /// <param name="model"></param>
        public override void Create(PurchaseOrder model)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    model.CreatedOn = DateTime.Now;
                    context.Insert(model);

                    // 插入采购配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.PurchaseOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        context.Insert(item);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 修改采购单
        /// <summary>
        /// 修改采购单，更新关联对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override void UpdateModel(PurchaseOrder model)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    // 修改采购单
                    context.Update(model);

                    // 删除历史采购单
                    context.Delete<PurchaseOrderProduct>(item => item.PurchaseOrderId == model.Id);

                    // 插入采购配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.PurchaseOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        context.Insert(item);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 获取采购单，填充关联对象
        /// <summary>
        /// 获取采购单，填充关联对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override PurchaseOrder GetModel(Guid Id)
        {
            using (var context = DbContext.Open())
            {
                var model = context.SingleById<PurchaseOrder>(Id);
                if (model == null)
                    return null;

                model.ProductList = PurchaseOrderProductRepository.Find(model.Id);
                model.PurchaseBy = EmployeeRepository.Get(model.PurchaseById);
                model.Supplier = SupplierRepository.Get(model.SupplierId);
                return model;
            }
        }
        #endregion

        #region 设置已到货
        /// <summary>
        /// 设置已到货
        /// </summary>
        /// <param name="model"></param>
        public void SetArrival(PurchaseOrder model)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                { 
                    // 修改采购单状态
                    model.Status = EnumPurchaseOrderStatus.Completed;
                    model.ArrivalOn = DateTime.Now;
                    context.Update(model);

                    // 库存入库
                    foreach (var item in model.ProductList)
                    {
                        var product = ProductRepository.Get(item.ProductId);
                        if (product == null)
                            throw new Exception(string.Format("获取配件信息失败，配件ID：{0}", item.ProductId));

                        // 插入配件出库记录
                        var record = new ProductStockRecord
                        {
                            Id = Guid.NewGuid(),
                            RelationId = model.Id,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                            Type = EnumStockRecordType.Purchase,
                            QuantityBefore = product.Stock,
                            CreatedOn = DateTime.Now,
                            RecordOn = model.ArrivalOn,
                        };
                        context.Insert(record);

                        // 修改产品的库存数量
                        product.Stock = product.Stock + item.Quantity;
                        context.Update(product);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion
    }
}
