using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.Products.Enum;
using Anchi.ERP.IRepository.Products;
using ServiceStack.OrmLite;
using System;

namespace Anchi.ERP.Repository.Products
{
    /// <summary>
    /// 配件管理仓储层
    /// </summary>
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region 修改配件
        /// <summary>
        /// 修改配件
        /// </summary>
        /// <param name="model"></param>
        public override void UpdateModel(Product model)
        {
            using (var context = DbContext.Open())
            {
                var temp = context.Single<Product>(model.Id);

                var stockDiff = model.Stock - temp.Stock;
                if (stockDiff != 0)
                {   // 修改配件库存，增加出入库记录
                    var record = new ProductStockRecord
                    {
                        Id = Guid.NewGuid(),
                        ProductId = model.Id,
                        Quantity = Math.Abs(stockDiff),
                        QuantityBefore = temp.Stock,
                        RelationId = model.Id,
                        Type = stockDiff > 0 ? EnumStockRecordType.ModifyStockIn : EnumStockRecordType.ModifyStockOut,
                        RecordOn = DateTime.Now,
                        CreatedOn = DateTime.Now,
                        Remark = "修改配件",
                    };
                    context.Insert(record);
                }

                context.Update(model);
            }
        }
        #endregion
    }
}
