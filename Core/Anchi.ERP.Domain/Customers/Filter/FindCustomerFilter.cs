using Anchi.ERP.Domain.Common;

namespace Anchi.ERP.Domain.Customers.Filter
{
    /// <summary>
    /// 查找客户信息筛选类
    /// </summary>
    public class FindCustomerFilter : PagedFilter
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get; set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get; set;
        }
    }
}
