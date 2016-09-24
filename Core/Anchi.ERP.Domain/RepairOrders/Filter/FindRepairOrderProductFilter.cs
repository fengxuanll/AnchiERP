using Anchi.ERP.Common.Filter;
using System;
using System.Text;

namespace Anchi.ERP.Domain.RepairOrders.Filter
{
    /// <summary>
    /// 维修单配件筛选器
    /// </summary>
    public class FindRepairOrderProductFilter : QueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [RepairOrderProduct] WHERE 1 = 1");
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
