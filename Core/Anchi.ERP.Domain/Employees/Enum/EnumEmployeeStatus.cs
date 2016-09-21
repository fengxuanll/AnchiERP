using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.Employees.Enum
{
    /// <summary>
    /// 员工状态
    /// </summary>
    [EnumAsInt]
    public enum EnumEmployeeStatus
    {
        /// <summary>
        ///  正常
        /// </summary>
        [Display(Name = "正常")]
        Normal = 1,
        /// <summary>
        /// 停用
        /// </summary>
        [Display(Name = "停用")]
        Disable = 2,
    }
}
