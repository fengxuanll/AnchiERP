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
    }
}
