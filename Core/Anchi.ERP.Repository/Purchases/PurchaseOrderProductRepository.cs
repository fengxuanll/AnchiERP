using Anchi.ERP.Repository.Products;
using Anchi.ERP.Domain.PurchaseOrders;
using Anchi.ERP.Domain.PurchaseOrders.Filter;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Repository.Purchases
{
    /// <summary>
    /// 采购单配件仓储层
    /// </summary>
    public class PurchaseOrderProductRepository : BaseRepository<PurchaseOrderProduct>
    {
        #region 构造函数和属性
        public PurchaseOrderProductRepository() : this(new ProductRepository()) { }

        public PurchaseOrderProductRepository(ProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }

        ProductRepository ProductRepository
        { get; }
        #endregion

        #region 获取采购单配件列表
        /// <summary>
        /// 获取采购单配件列表
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        public IList<PurchaseOrderProduct> Find(Guid purchaseOrderId)
        {
            var filter = new FindPurchaseOrderProductFilter();
            filter.PurchaseOrderId = purchaseOrderId;
            var modelList = this.Find<PurchaseOrderProduct>(filter);

            foreach (var item in modelList)
            {
                item.Product = ProductRepository.Get(item.ProductId);
            }
            return modelList;
        }
        #endregion
    }
}
