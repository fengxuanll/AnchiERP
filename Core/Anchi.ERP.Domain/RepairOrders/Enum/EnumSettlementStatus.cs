using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.RepairOrders.Enum
{
    /// <summary>
    /// 结算状态
    /// </summary>
    [EnumAsInt]
    public enum EnumSettlementStatus
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
        /// <summary>
        /// 部分结算
        /// </summary>
        [Display(Name = "部分结算")]
        PartCompleted = 3,
    }
}
