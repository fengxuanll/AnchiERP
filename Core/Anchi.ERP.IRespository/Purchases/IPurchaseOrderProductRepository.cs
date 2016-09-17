using Anchi.ERP.Domain.PurchaseOrders;
using Anchi.ERP.IRespository;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.IRepository.Purchases
{
    /// <summary>
    /// 采购单配件明细仓储层接口
    /// </summary>
    public interface IPurchaseOrderProductRepository : IBaseRepository<PurchaseOrderProduct>
    {
        /// <summary>
        /// 获取采购单配件列表
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        IList<PurchaseOrderProduct> Find(Guid purchaseOrderId);
    }
}
