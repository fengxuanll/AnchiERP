using ServiceStack.DataAnnotations;

namespace Anchi.ERP.Domain.Employees.Enum
{
    /// <summary>
    /// 员工状态
    /// </summary>
    [EnumAsInt]
    public enum EnumEmployeeStatus : byte
    {
        /// <summary>
        ///  正常
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 停用
        /// </summary>
        Disable = 2,
    }
}
