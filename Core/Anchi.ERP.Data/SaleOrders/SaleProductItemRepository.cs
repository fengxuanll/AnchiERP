using Anchi.ERP.Data.Products;
using Anchi.ERP.Domain.SaleOrders;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Data.SaleOrders
{
    /// <summary>
    /// 销售配件仓储层
    /// </summary>
    public class SaleProductItemRepository : BaseRepository<SaleProductItem>
    {
        #region 构造函数和属性
        public SaleProductItemRepository() : this(new ProductRepository()) { }

        public SaleProductItemRepository(ProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }

        ProductRepository ProductRepository { get; }
        #endregion

        #region 根据销售单ID获取销售配件
        /// <summary>
        /// 根据销售单ID获取销售配件
        /// </summary>
        /// <param name="saleOrderId"></param>
        /// <returns></returns>
        public IList<SaleProductItem> Find(Guid saleOrderId)
        {
            using (var db = DbFactory.Open())
            {
                var modelList = db.Select<SaleProductItem>(item => item.SaleOrderId == saleOrderId);
                foreach (var item in modelList)
                {
                    item.Product = ProductRepository.GetModel(item.ProductId);
                }
                return modelList;
            }
        }
        #endregion
    }
}
