using Anchi.ERP.Common;
using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.Projects;
using Anchi.ERP.Domain.Users;
using ServiceStack.DataAnnotations;
using System;

namespace Anchi.ERP.Domain.RepairOrder
{
    /// <summary>
    /// 维修项目
    /// </summary>
    public class RepairOrderItem : BaseDomain
    {
        /// <summary>
        /// 维修单ID
        /// </summary>
        [Required]
        public Guid RepairOrderId
        {
            get; set;
        }

        /// <summary>
        /// 修改项目ID
        /// </summary>
        [Required]
        [References(typeof(Project))]
        public Guid ProjectId
        {
            get; set;
        }

        /// <summary>
        /// 维修项目
        /// </summary>
        [Reference]
        public virtual Project Project
        {
            get; set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        [Required]
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// 数量
        /// </summary>
        [Required]
        public int Quantity
        {
            get; set;
        }

        /// <summary>
        /// 维修工
        /// </summary>
        [Reference]
        public virtual Employee Employee
        {
            get; set;
        }

        /// <summary>
        /// 维修工ID
        /// </summary>
        [Required]
        [References(typeof(Employee))]
        public Guid EmployeeId
        {
            get; set;
        }

        private DateTime beginOn;
        /// <summary>
        /// 开始时间
        /// </summary>
        [Required]
        [StringLength(30)]
        public DateTime BeginOn
        {
            get
            {
                if (beginOn < SqlDateTime.Min)
                    beginOn = SqlDateTime.Min;

                return beginOn;
            }
            set
            {
                beginOn = value;
            }
        }


        private DateTime endOn;
        /// <summary>
        /// 完工时间
        /// </summary>
        [Required]
        [StringLength(30)]
        public DateTime EndOn
        {
            get
            {
                if (endOn < SqlDateTime.Min)
                    endOn = SqlDateTime.Min;

                return endOn;
            }
            set
            {
                endOn = value;
            }
        }
    }
}
