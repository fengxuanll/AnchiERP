using Anchi.ERP.Domain.SaleOrders;
using Anchi.ERP.IRespository;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.IRepository.SaleOrders
{
    /// <summary>
    /// 销售单配件明细仓储层接口
    /// </summary>
    public interface ISaleOrderProductRepository : IBaseRepository<SaleOrderProduct>
    {
        /// <summary>
        /// 获取销售单的配件明细
        /// </summary>
        /// <param name="saleOrderId"></param>
        /// <returns></returns>
        IList<SaleOrderProduct> Find(Guid saleOrderId);
    }
}
