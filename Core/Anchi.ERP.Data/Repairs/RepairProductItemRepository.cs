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
        #region 根据维修单ID获取使用的配件列表
        /// <summary>
        /// 根据维修单ID获取使用的配件列表
        /// </summary>
        /// <param name="repairOrderId"></param>
        /// <returns></returns>
        public IList<RepairProductItem> Find(Guid repairOrderId)
        {
            using (var db = DbFactory.Open())
            {
                return db.Select<RepairProductItem>(item => item.RepairOrderId == repairOrderId);
            }
        }
        #endregion
    }
}
