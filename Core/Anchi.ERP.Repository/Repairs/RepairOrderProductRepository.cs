using Anchi.ERP.Repository.Products;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Domain.RepairOrders.Filter;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Repository.Repairs
{
    /// <summary>
    /// 维修单配件明细仓储层
    /// </summary>
    public class RepairOrderProductRepository : BaseRepository<RepairOrderProduct>
    {
        #region 构造函数和属性
        public RepairOrderProductRepository() : this(new ProductRepository()) { }

        public RepairOrderProductRepository(ProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }

        ProductRepository ProductRepository { get; }
        #endregion

        #region 根据维修单ID获取使用的配件列表
        /// <summary>
        /// 根据维修单ID获取使用的配件列表
        /// </summary>
        /// <param name="repairOrderId"></param>
        /// <returns></returns>
        public IList<RepairOrderProduct> Find(Guid repairOrderId)
        {
            var filter = new FindRepairOrderProductFilter();
            filter.RepairOrderId = repairOrderId;
            var modelList = base.Find<RepairOrderProduct>(filter);
            foreach (var model in modelList)
            {
                model.Product = ProductRepository.Get(model.ProductId);
            }

            return modelList;
        }
        #endregion
    }
}
