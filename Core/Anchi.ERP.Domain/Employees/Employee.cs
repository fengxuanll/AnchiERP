using Anchi.ERP.Common;
using Anchi.ERP.Domain.Employees.Enum;
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
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
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

        private DateTime entryOn;
        /// <summary>
        /// 入职时间
        /// </summary>
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
        public EnumEmployeeStatus Status
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
