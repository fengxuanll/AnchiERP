using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "未结算")]
        Waiting = 1,
        /// <summary>
        /// 已结算
        /// </summary>
        [Display(Name = "已结算")]
        Completed = 2,
    }
}
