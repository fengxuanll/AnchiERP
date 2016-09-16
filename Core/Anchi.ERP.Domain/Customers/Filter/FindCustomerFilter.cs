using Anchi.ERP.Common.Filter;
using System.Text;

namespace Anchi.ERP.Domain.Customers.Filter
{
    /// <summary>
    /// 查找客户信息筛选类
    /// </summary>
    public class FindCustomerFilter : PagedQueryFilter
    {
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [Customer] WHERE 1 = 1");

                if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    sb.Append(" AND [Name] = @Name");
                    this.ParamDict["@Name"] = this.Name;
                }
                if (!string.IsNullOrWhiteSpace(this.CarNumber))
                {
                    sb.Append(" AND [CarNumber] = @CarNumber");
                    this.ParamDict["@CarNumber"] = this.CarNumber;
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNumber
        {
            get; set;
        }
    }
}
