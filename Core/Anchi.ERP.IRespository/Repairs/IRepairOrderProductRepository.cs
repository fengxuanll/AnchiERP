using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.IRespository;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.IRepository.Repairs
{
    /// <summary>
    /// 维修单配件明细仓储层接口
    /// </summary>
    public interface IRepairOrderProductRepository : IBaseRepository<RepairOrderProduct>
    {
        /// <summary>
        /// 获取维修单的配件明细
        /// </summary>
        /// <param name="repairOrderId"></param>
        /// <returns></returns>
        IList<RepairOrderProduct> Find(Guid repairOrderId);
    }
}
