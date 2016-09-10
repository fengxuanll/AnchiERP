using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.PurchaseOrders;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Data.Purchases
{
    /// <summary>
    /// 采购单配件仓储层
    /// </summary>
    public class PurchaseOrderProductRepository : BaseRepository<PurchaseOrderProduct>
    {
        #region 根据采购单号获取采购配件
        /// <summary>
        /// 根据采购单号获取采购配件
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        public IList<PurchaseOrderProduct> Find(Guid purchaseOrderId)
        {
            using (var db = DbFactory.Open())
            {
                var modelList= db.Select<PurchaseOrderProduct>(item => item.PurchaseOrderId == purchaseOrderId);
                foreach (var item in modelList)
                {
                    item.Product = db.SingleById<Product>(item.ProductId);
                }
                return modelList;
            }
        }
        #endregion
    }
}
