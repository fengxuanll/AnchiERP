using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.RepairOrder.Enum
{
    /// <summary>
    /// 维修单状态
    /// </summary>
    public enum EnumRepairOrderStatus : byte
    {
        /// <summary>
        /// 维修中
        /// </summary>
        [Display(Name = "维修中")]
        Repairing = 1,
        /// <summary>
        /// 维修完成
        /// </summary>
        [Display(Name = "已完工")]
        Completed = 2,
    }
}
