using Anchi.ERP.Domain.Users.Enum;
using System;

namespace Anchi.ERP.Domain.Users
{
    /// <summary>
    /// 用户信息
    /// </summary>
    [Serializable]
    public class User : BaseDomain
    {
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
        /// 密码
        /// </summary>
        public string Password
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
        /// 状态
        /// </summary>
        public EnumUserStatus Status
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }
    }
}
