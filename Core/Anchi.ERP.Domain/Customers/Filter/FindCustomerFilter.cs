using System;
using Anchi.ERP.Common.Filter;

namespace Anchi.ERP.Domain.Customers.Filter
{
    /// <summary>
    /// 查找客户信息筛选类
    /// </summary>
    public class FindCustomerFilter : PagedQueryFilter
    {
        public override string SQL
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get; set;
        }
    }
}
