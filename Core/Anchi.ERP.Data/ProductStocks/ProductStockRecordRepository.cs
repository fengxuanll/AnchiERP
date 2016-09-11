using Anchi.ERP.Domain.Products;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Data.ProductStocks
{
    /// <summary>
    /// 配件库存记录仓储类
    /// </summary>
    public class ProductStockRecordRepository : BaseRepository<ProductStockRecord>
    {
        #region 根据产品ID获取库存记录
        /// <summary>
        /// 根据产品ID获取库存记录
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public IList<ProductStockRecord> Find(Guid productId)
        {
            using (var db = DbFactory.Open())
            {
                return db.Select<ProductStockRecord>(item => item.ProductId == productId);
            }
        }
        #endregion
    }
}
