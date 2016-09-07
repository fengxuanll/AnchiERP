using Anchi.ERP.Domain.PurchaseOrders;
using System;
using ServiceStack.OrmLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anchi.ERP.Data.Purchases
{
    /// <summary>
    /// 采购仓储类
    /// </summary>
    public class PurchaseOrderRepository : BaseRepository<PurchaseOrder>
    {
        #region 构造函数和属性
        public PurchaseOrderRepository() : this(new PurchaseOrderProductRepository()) { }

        public PurchaseOrderRepository(PurchaseOrderProductRepository purchaseOrderProductRepository)
        {
            this.PurchaseOrderProductRepository = purchaseOrderProductRepository;
        }

        PurchaseOrderProductRepository PurchaseOrderProductRepository
        {
            get;
        }
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
                    tran.Commit();
                }
            }
            return 0;
        }
        #endregion

        #region 获取采购单
        /// <summary>
        /// 获取采购单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public override PurchaseOrder GetById(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                return null;
            }
        }
        #endregion
    }
}
