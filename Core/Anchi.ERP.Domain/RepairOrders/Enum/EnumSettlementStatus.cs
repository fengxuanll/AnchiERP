using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anchi.ERP.Domain.RepairOrder.Enum
{
    /// <summary>
    /// 结算状态
    /// </summary>
    public enum EnumSettlementStatus : byte
    {
        /// <summary>
        /// 未结算
        /// </summary>
        Waiting = 1,
        /// <summary>
        /// 已结算
        /// </summary>
        Completed = 2,
    }
}
