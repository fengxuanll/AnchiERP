using Anchi.ERP.Data.ProductStocks;
using Anchi.ERP.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anchi.ERP.Service.ProductStocks
{
    /// <summary>
    /// 产品库存记录服务类
    /// </summary>
    public class ProductStockRecordService : BaseService<ProductStockRecord>
    {
        #region 构造函数和属性
        public ProductStockRecordService() : this(new ProductStockRecordRepository()) { }

        public ProductStockRecordService(ProductStockRecordRepository productStockRecordRepository) : base(productStockRecordRepository)
        {
            this.ProductStockRecordRepository = productStockRecordRepository;
        }

        ProductStockRecordRepository ProductStockRecordRepository
        {
            get;
        }
        #endregion

        #region 根据产品ID获取库存记录
        /// <summary>
        /// 根据产品ID获取库存记录
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<ProductStockRecord> Find(Guid productId)
        {
            if (productId == Guid.Empty)
                return new List<ProductStockRecord>();

            return ProductStockRecordRepository.Find(productId);
        }
        #endregion
    }
}
