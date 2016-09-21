
using ServiceStack.DataAnnotations;

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
        Normal = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        Disable = 2,
    }
}
