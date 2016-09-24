using Anchi.ERP.Common.Filter;
using System;
using System.Text;

namespace Anchi.ERP.Domain.RepairOrders.Filter
{
    /// <summary>
    /// 维修单项目筛选器
    /// </summary>
    public class FindRepairOrderProjectFilter : QueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [RepairOrderProject] WHERE 1 = 1");
                if (RepairOrderId.HasValue)
                {
                    sb.Append(" AND RepairOrderId = @RepairOrderId");
                    this.ParamDict["@RepairOrderId"] = this.RepairOrderId.Value;
                }
                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 维修单ID
        /// </summary>
        public Guid? RepairOrderId
        {
            get; set;
        }
    }
}
