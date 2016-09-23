using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.Sequences.Enum
{
    /// <summary>
    /// 序列类型
    /// </summary>
    [EnumAsInt]
    public enum EnumSequenceType
    {
        /// <summary>
        /// 维修单编码序列
        /// </summary>
        [Display(Description = "维修单编码序列")]
        Repair = 1,
        /// <summary>
        /// 销售单编码序列
        /// </summary>
        [Display(Description = "销售单编码序列")]
        Sale = 2,
        /// <summary>
        /// 采购单编码序列
        /// </summary>
        [Display(Description = "采购单编码序列")]
        Purchase = 3,
        /// <summary>
        /// 财务单编码序列
        /// </summary>
        [Display(Description = "财务单编码序列")]
        Finance = 4,
    }
}
