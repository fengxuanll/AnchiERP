using Anchi.ERP.Domain.Common.Enum;

namespace Anchi.ERP.Domain.Common
{
    /// <summary>
    /// 分页查询
    /// </summary>
    public class PagedFilter
    {
        private int pageSize;
        /// <summary>
        /// 分页大小，默认20
        /// </summary>
        public int PageSize
        {
            get
            {
                if (pageSize <= 0)
                    pageSize = 20;

                return pageSize;
            }
            set
            {
                pageSize = value;
            }
        }

        /// <summary>
        /// 当前页索引，从0开始
        /// </summary>
        public int PageIndex
        {
            get; set;
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public string OrderBy
        {
            get; set;
        }

        /// <summary>
        /// 排序方向  ASC/DESC
        /// </summary>
        public EnumOrderbySort Sort
        {
            get; set;
        }
    }
}
