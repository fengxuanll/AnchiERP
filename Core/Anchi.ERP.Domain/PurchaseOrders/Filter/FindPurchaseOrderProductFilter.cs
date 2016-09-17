using Anchi.ERP.Common.Filter;
using System;
using System.Text;

namespace Anchi.ERP.Domain.PurchaseOrders.Filter
{
    /// <summary>
    /// 采购单配件筛选器
    /// </summary>
    public class FindPurchaseOrderProductFilter : QueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [PurchaseOrderProduct] WHERE 1 = 1");
                if (this.PurchaseOrderId.HasValue)
                {
                    sb.Append(" AND PurchaseOrderId = @PurchaseOrderId");
                    this.ParamDict["@PurchaseOrderId"] = this.PurchaseOrderId.Value;
                }
                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 采购单ID
        /// </summary>
        public Guid? PurchaseOrderId
        {
            get; set;
        }
    }
}
