using Anchi.ERP.Data.Repository.Products;
using Anchi.ERP.Domain.Products;
using System;

namespace Anchi.ERP.Service.Products
{
    /// <summary>
    /// 配件管理服务类
    /// </summary>
    public class ProductService : BaseService<Product>
    {
        #region 构造函数和属性
        public ProductService() : this(new ProductRepository()) { }

        public ProductService(ProductRepository productRepository) : base(productRepository)
        {
            this.ProductRepository = productRepository;
        }

        ProductRepository ProductRepository { get; }
        #endregion

        #region 保存配件
        /// <summary>
        /// 保存配件
        /// </summary>
        /// <param name="model"></param>
        public Product SaveOrUpdate(Product model)
        {
            if (model == null)
                throw new Exception("提交数据错误。");

            if (string.IsNullOrWhiteSpace(model.Code))
                throw new Exception("请输入配件编码。");

            if (string.IsNullOrWhiteSpace(model.Name))
                throw new Exception("请输入配件名称。");

            var temp = GetModel(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                ProductRepository.Create(model);
            }
            else
            {
                temp.Code = model.Code;
                temp.Name = model.Name;
                temp.Remark = model.Remark;
                temp.SafeStock = model.SafeStock;
                temp.CostPrice = model.CostPrice;
                temp.SalePrice = model.SalePrice;
                temp.Stock = model.Stock;
                ProductRepository.Update(temp);
            }
            return model;
        }
        #endregion
    }
}
