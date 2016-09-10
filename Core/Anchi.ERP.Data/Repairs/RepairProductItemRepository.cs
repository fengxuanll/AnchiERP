using Anchi.ERP.Data.Products;
using Anchi.ERP.Domain.RepairOrder;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Data.Repairs
{
    /// <summary>
    /// 维修单配件明细仓储层
    /// </summary>
    public class RepairProductItemRepository : BaseRepository<RepairProductItem>
    {
        #region 构造函数和属性
        public RepairProductItemRepository() : this(new ProductRepository()) { }

        public RepairProductItemRepository(ProductRepository productRepository)
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
        public IList<RepairProductItem> Find(Guid repairOrderId)
        {
            IList<RepairProductItem> modelList = null;
            using (var db = DbFactory.Open())
            {
                modelList = db.Select<RepairProductItem>(item => item.RepairOrderId == repairOrderId);
            }
            modelList = modelList ?? new List<RepairProductItem>();

            foreach (var model in modelList)
            {
                model.Product = ProductRepository.GetById(model.ProductId);
            }

            return modelList;
        }
        #endregion
    }
}
