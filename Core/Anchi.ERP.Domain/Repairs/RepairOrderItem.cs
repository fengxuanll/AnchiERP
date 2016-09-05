using Anchi.ERP.Domain.Projects;
using Anchi.ERP.Domain.Users;
using System;

namespace Anchi.ERP.Domain.Repairs
{
    /// <summary>
    /// 维修项目
    /// </summary>
    public class RepairOrderItem : BaseDomain
    {
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
        public decimal Price
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
        public User Worker
        {
            get; set;
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime BeginOn
        {
            get; set;
        }

        /// <summary>
        /// 完工时间
        /// </summary>
        public DateTime EndOn
        {
            get; set;
        }
    }
}
