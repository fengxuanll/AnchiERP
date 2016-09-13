using Anchi.ERP.Common.Filter.Enum;

namespace Anchi.ERP.Common.Filter
{
    /// <summary>
    /// 分页查询筛选器
    /// </summary>
    public abstract class PagedQueryFilter : QueryFilter
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
