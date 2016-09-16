using Anchi.ERP.Common.Filter;
using System.Text;

namespace Anchi.ERP.Domain.Products.Filter
{
    /// <summary>
    /// 查找配件筛选器
    /// </summary>
    public class FindProductFilter : PagedQueryFilter
    {
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [Product] WHERE 1 = 1");

                if (!string.IsNullOrWhiteSpace(this.Code))
                {
                    sb.Append(" AND [Code] = @Code");
                    this.ParamDict["@Code"] = this.Code;
                }
                if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    sb.Append(" AND [Name] = @Name");
                    this.ParamDict["@Name"] = this.Name;
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// 配件编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 配件名称
        /// </summary>
        public string Name
        {
            get; set;
        }
    }
}
