using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.IRespository;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.IRepository.Repairs
{
    /// <summary>
    /// 财务单维修项目仓储层接口
    /// </summary>
    public interface IRepairOrderProjectRepository : IBaseRepository<RepairOrderProject>
    {
        /// <summary>
        /// 获取财务单的维修项目
        /// </summary>
        /// <param name="repairOrderId"></param>
        /// <returns></returns>
        IList<RepairOrderProject> Find(Guid repairOrderId);
    }
}
