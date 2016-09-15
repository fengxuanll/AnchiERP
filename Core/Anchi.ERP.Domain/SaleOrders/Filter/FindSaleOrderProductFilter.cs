using Anchi.ERP.Common.Filter;
using System;
using System.Text;

namespace Anchi.ERP.Domain.SaleOrders.Filter
{
    /// <summary>
    /// 销售单配件筛选类
    /// </summary>
    public class FindSaleOrderProductFilter : QueryFilter
    {
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [SaleOrderProduct] WHERE 1 = 1");
                if (SaleOrderId.HasValue)
                {
                    sb.Append(" AND SaleOrderId = @SaleOrderId");
                    this.ParamDict["@SaleOrderId"] = this.SaleOrderId.Value;
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// 销售单ID
        /// </summary>
        public Guid? SaleOrderId
        {
            get; set;
        }
    }
}
