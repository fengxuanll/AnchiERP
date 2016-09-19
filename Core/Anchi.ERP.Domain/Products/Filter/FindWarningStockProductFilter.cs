using Anchi.ERP.Common.Filter;
using System.Text;

namespace Anchi.ERP.Domain.Products.Filter
{
    /// <summary>
    /// 查找库存预警的配件
    /// </summary>
    public class FindWarningStockProductFilter : PagedQueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [Product] WHERE 1 = 1");
                sb.Append(" AND Stock <= SafeStock");
                return sb.ToString();
            }
        }
        #endregion
    }
}
