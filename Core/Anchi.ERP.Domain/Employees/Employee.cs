using Anchi.ERP.Common;
using Anchi.ERP.Domain.Employees.Enum;
using ServiceStack.DataAnnotations;
using System;

namespace Anchi.ERP.Domain.Employees
{
    /// <summary>
    /// 员工信息
    /// </summary>
    public class Employee : BaseDomain
    {
        /// <summary>
        /// 编码
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 身份证号
        /// </summary>
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

        private DateTime entryOn;
        /// <summary>
        /// 入职时间
        /// </summary>
        [Required]
        [StringLength(30)]
        public DateTime EntryOn
        {
            get
            {
                if (entryOn < SqlDateTime.Min)
                    entryOn = SqlDateTime.Min;

                return entryOn;
            }
            set
            {
                entryOn = value;
            }
        }

        /// <summary>
        /// 在职状态
        /// </summary>
        [Required]
        [StringLength(30)]
        public EnumEmployeeStatus Status
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
