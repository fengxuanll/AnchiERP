using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.Projects;
using System;

namespace Anchi.ERP.Domain.RepairOrder
{
    /// <summary>
    /// 维修项目
    /// </summary>
    public class RepairOrderProject : BaseDomain
    {
        /// <summary>
        /// 维修单ID
        /// </summary>
        public Guid RepairOrderId
        {
            get; set;
        }

        /// <summary>
        /// 修改项目ID
        /// </summary>
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
        public decimal UnitPrice
        {
            get; set;
        }

        /// <summary>
        /// 数量
        /// </summary>
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
        public Guid EmployeeId
        {
            get; set;
        }
    }
}
