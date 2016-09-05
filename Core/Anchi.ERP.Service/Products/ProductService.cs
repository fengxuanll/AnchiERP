using Anchi.ERP.Data.Products;
using Anchi.ERP.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anchi.ERP.Service.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductService : BaseService<Product>
    {
        public ProductService() : this(new ProductRepository())
        { }

        public ProductService(ProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
            base.Repository = productRepository;
        }

        ProductRepository ProductRepository
        {
            get;
        }

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

            var temp = GetById(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                ProductRepository.Create(model);
            }
            else
            {
                ProductRepository.Update(model);
            }
            return model;
        }
    }
}
