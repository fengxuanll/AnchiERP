using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.Users.Enum;

namespace Anchi.ERP.Domain.Users.Filter
{
    /// <summary>
    /// 查找用户信息筛选类
    /// </summary>
    public class FindUserFilter : PagedFilter
    {
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get; set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get; set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard
        {
            get; set;
        }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName
        {
            get; set;
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get; set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumUserStatus? Status
        {
            get; set;
        }
    }
}
