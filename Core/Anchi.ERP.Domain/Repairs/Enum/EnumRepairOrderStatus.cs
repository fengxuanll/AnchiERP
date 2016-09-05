using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Anchi.ERP.Domain.Repairs.Enum
{
    /// <summary>
    /// 维修单状态
    /// </summary>
    public enum EnumRepairOrderStatus : byte
    {
        /// <summary>
        /// 维修中
        /// </summary>
        Repairing = 1,
        /// <summary>
        /// 维修完成
        /// </summary>
        Completed = 2,
    }
}
