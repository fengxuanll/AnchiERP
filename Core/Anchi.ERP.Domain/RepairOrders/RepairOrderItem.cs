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
        public Guid ProjectId
        {
            get; set;
        }

        /// <summary>
        /// 维修项目
        /// </summary>
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
        public virtual Employee Employee
        {
            get; set;
        }

        /// <summary>
        /// 维修工ID
        /// </summary>
        [Required]
        public Guid EmployeeId
        {
            get; set;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        [Required]
        [StringLength(30)]
        public DateTime BeginOn
        {
            get; set;
        }

        /// <summary>
        /// 完工时间
        /// </summary>
        [Required]
        [StringLength(30)]
        public DateTime EndOn
        {
            get; set;
        }
    }
}
