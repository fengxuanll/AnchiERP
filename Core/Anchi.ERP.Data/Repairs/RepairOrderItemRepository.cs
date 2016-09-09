using Anchi.ERP.Domain.RepairOrder;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Data.Repairs
{
    /// <summary>
    /// 维修单项目仓储层
    /// </summary>
    public class RepairOrderItemRepository : BaseRepository<RepairOrderItem>
    {
        #region 根据维修单ID获取项目列表
        /// <summary>
        /// 根据维修单ID获取项目列表
        /// </summary>
        /// <param name="repairOrderId"></param>
        /// <returns></returns>
        public IList<RepairOrderItem> Find(Guid repairOrderId)
        {
            using (var db = DbFactory.Open())
            {
                return db.Select<RepairOrderItem>(item => item.RepairOrderId == repairOrderId);
            }
        }
        #endregion  
    }
}
