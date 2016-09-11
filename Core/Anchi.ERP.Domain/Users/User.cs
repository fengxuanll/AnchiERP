using Anchi.ERP.Domain.Users.Enum;
using ServiceStack.DataAnnotations;
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
        [Required]
        [StringLength(10)]
        public string TrueName
        {
            get; set;
        }

        /// <summary>
        /// 登录名
        /// </summary>
        [Required]
        [Index(unique: true)]
        [StringLength(20)]
        public string LoginName
        {
            get; set;
        }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Password
        {
            get; set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        [Index(unique: true)]
        [StringLength(18)]
        public string IDCard
        {
            get; set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        [StringLength(50)]
        public string Tel
        {
            get; set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(100)]
        public string Address
        {
            get; set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        [StringLength(10)]
        public EnumUserStatus Status
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(1000)]
        public string Remark
        {
            get; set;
        }
    }
}
