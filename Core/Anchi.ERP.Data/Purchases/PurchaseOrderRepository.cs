using Anchi.ERP.Data.Employees;
using Anchi.ERP.Data.Suppliers;
using Anchi.ERP.Domain.PurchaseOrders;
using ServiceStack.OrmLite;
using System;

namespace Anchi.ERP.Data.Purchases
{
    /// <summary>
    /// 采购仓储类
    /// </summary>
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>
    {
        #region 构造函数和属性
        public PurchaseOrderRepository() : this(new PurchaseOrderProductRepository(), new EmployeeRepository(), new SupplierRepository()) { }

        public PurchaseOrderRepository(PurchaseOrderProductRepository purchaseOrderProductRepository, EmployeeRepository employeeRepository, SupplierRepository supplierRepository)
        {
            this.PurchaseOrderProductRepository = purchaseOrderProductRepository;
            this.EmployeeRepository = employeeRepository;
            this.SupplierRepository = supplierRepository;
        }

        PurchaseOrderProductRepository PurchaseOrderProductRepository { get; }
        EmployeeRepository EmployeeRepository { get; }
        SupplierRepository SupplierRepository { get; }
        #endregion

        #region 创建采购单
        /// <summary>
        /// 创建采购单
        /// </summary>
        /// <param name="model"></param>
        public override void Create(PurchaseOrder model)
        {
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    model.CreatedOn = DateTime.Now;
                    db.Insert(model);

                    // 插入采购配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.PurchaseOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }

                    tran.Commit();
                }
            }
        }
        #endregion

        #region 修改采购单
        /// <summary>
        /// 修改采购单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public override int Update(PurchaseOrder model)
        {
            using (var db = DbFactory.Open())
            {
                using (var tran = db.BeginTransaction())
                {
                    db.Update(model);

                    // 删除历史采购配件
                    db.Delete<PurchaseOrderProduct>(item => item.PurchaseOrderId == model.Id);

                    // 插入采购配件
                    foreach (var item in model.ProductList)
                    {
                        item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                        item.PurchaseOrderId = model.Id;
                        item.CreatedOn = model.CreatedOn;
                        db.Insert(item);
                    }

                    tran.Commit();
                }
            }
            return 0;
        }
        #endregion

        #region 获取采购单
        /// <summary>
        /// 获取采购单，填充关联对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override PurchaseOrder GetById(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                var model = db.SingleById<PurchaseOrder>(Id);
                if (model == null)
                    return null;

                model.ProductList = PurchaseOrderProductRepository.Find(model.Id);
                model.PurchaseBy = EmployeeRepository.GetById(model.PurchaseById);
                model.Supplier = SupplierRepository.GetById(model.SupplierId);
                return model;
            }
        }
        #endregion
    }
}
