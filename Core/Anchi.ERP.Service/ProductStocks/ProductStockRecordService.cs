using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Products;
using Anchi.ERP.Repository.Products;
using Anchi.ERP.Service.Products;
using Anchi.ERP.ServiceModel.Products;
using System.Collections.Generic;

namespace Anchi.ERP.Service.ProductStocks
{
    /// <summary>
    /// 产品库存记录服务类
    /// </summary>
    public class ProductStockRecordService : BaseService<ProductStockRecord>
    {
        #region 构造函数和属性
        public ProductStockRecordService() : this(new ProductStockRecordRepository(), new ProductService()) { }

        public ProductStockRecordService(ProductStockRecordRepository productStockRecordRepository, ProductService productService) : base(productStockRecordRepository)
        {
            this.ProductStockRecordRepository = productStockRecordRepository;
            this.ProductService = productService;
        }

        ProductStockRecordRepository ProductStockRecordRepository { get; }
        ProductService ProductService { get; }
        #endregion

        #region 查找出入库记录列表
        /// <summary>
        /// 查找出入库记录列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PagedQueryResult<ProductStockRecordModel> FindList(PagedQueryFilter filter)
        {
            var result = ProductStockRecordRepository.FindPaged<ProductStockRecord>(filter);
            var modelList = new List<ProductStockRecordModel>();
            var response = new PagedQueryResult<ProductStockRecordModel>();
            foreach (var item in result.Data)
            {
                var product = ProductService.GetModel(item.ProductId);
                var model = new ProductStockRecordModel
                {
                    Id = item.Id,
                    Stock = product == null ? 0 : product.Stock,
                    ProductCode = product == null ? string.Empty : product.Code,
                    ProductName = product == null ? string.Empty : product.Name,
                    Quantity = item.Quantity,
                    QuantityBefore = item.QuantityBefore,
                    RecordOn = item.RecordOn,
                    Type = item.Type,
                };
                modelList.Add(model);
            }
            response.Data = modelList;
            response.PageIndex = result.PageIndex;
            response.PageSize = result.PageSize;
            response.TotalCount = result.TotalCount;
            response.TotalPage = result.TotalPage;

            return response;
        }
        #endregion
    }
}
