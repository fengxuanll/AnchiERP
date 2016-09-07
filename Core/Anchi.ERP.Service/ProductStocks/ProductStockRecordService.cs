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

        public ProductStockRecordService(ProductStockRecordRepository productStockRecordRepository)
        {
            this.ProductStockRecordRepository = productStockRecordRepository;
            base.Repository = productStockRecordRepository;
        }

        ProductStockRecordRepository ProductStockRecordRepository
        {
            get;
        }
        #endregion
    }
}
