using Anchi.ERP.Repository.Products;
using Anchi.ERP.Domain.SaleOrders;
using Anchi.ERP.Domain.SaleOrders.Filter;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Repository.SaleOrders
{
    /// <summary>
    /// 销售配件仓储层
    /// </summary>
    public class SaleOrderProductRepository : BaseRepository<SaleOrderProduct>
    {
        #region 构造函数和属性
        public SaleOrderProductRepository() : this(new ProductRepository()) { }

        public SaleOrderProductRepository(ProductRepository productRepository)
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
        public IList<SaleOrderProduct> Find(Guid saleOrderId)
        {
            var filter = new FindSaleOrderProductFilter();
            filter.SaleOrderId = saleOrderId;
            var modelList = this.Find<SaleOrderProduct>(filter);
            foreach (var item in modelList)
            {
                item.Product = ProductRepository.GetModel(item.ProductId);
            }
            return modelList;
        }
        #endregion
    }
}
