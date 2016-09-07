using Anchi.ERP.Common;
using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.Projects;
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
        [Ignore]
        public virtual Project Project
        {
            get; set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        [Required]
        public decimal UnitPrice
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
        [Ignore]
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
    }
}
