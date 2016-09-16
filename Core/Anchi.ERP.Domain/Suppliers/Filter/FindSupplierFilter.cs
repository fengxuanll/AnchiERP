using Anchi.ERP.Common.Filter;
using System;
using System.Text;

namespace Anchi.ERP.Domain.Suppliers.Filter
{
    /// <summary>
    /// 查找供应商筛选类
    /// </summary>
    public class FindSupplierFilter : PagedQueryFilter
    {
        #region 要执行的SQL
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder("SELECT * FROM [Supplier] WHERE 1 = 1");
                if (!string.IsNullOrWhiteSpace(this.CompanyName))
                {
                    sb.Append(" AND CompanyName = @CompanyName");
                    this.ParamDict["@CompanyName"] = this.CompanyName;
                }
                if (!string.IsNullOrWhiteSpace(this.Contact))
                {
                    sb.Append(" AND Contact = @Contact");
                    this.ParamDict["@Contact"] = this.Contact;
                }
                return sb.ToString();
            }
        }
        #endregion

        /// <summary>
        /// 供应商名称
        /// </summary>
        public string CompanyName
        {
            get; set;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact
        {
            get; set;
        }
    }
}
