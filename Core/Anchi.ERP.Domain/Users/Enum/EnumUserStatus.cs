
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Anchi.ERP.Domain.Users.Enum
{
    /// <summary>
    /// 用户状态
    /// </summary>
    [EnumAsInt]
    public enum EnumUserStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Display(Name = "正常")]
        Normal = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        [Display(Name = "停用")]
        Disable = 2,
    }
}
