using Anchi.ERP.Common.Filter;
using System.Text;

namespace Anchi.ERP.Domain.Projects.Filter
{
    /// <summary>
    /// 查找维修项目筛选器
    /// </summary>
    public class FindProjectFilter : PagedQueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [Project] WHERE 1 = 1");

                if (!string.IsNullOrWhiteSpace(this.Code))
                {
                    sb.Append(" AND CHARINDEX(@Code, [Code])");
                    this.ParamDict["@Code"] = this.Code;
                }
                if (!string.IsNullOrWhiteSpace(this.Name))
                {
                    sb.Append(" AND CHARINDEX(@Name, [Name])");
                    this.ParamDict["@Name"] = this.Name;
                }

                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 项目编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            get; set;
        }
    }
}
