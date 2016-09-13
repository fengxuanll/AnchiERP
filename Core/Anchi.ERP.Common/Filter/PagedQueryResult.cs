using System.Collections.Generic;

namespace Anchi.ERP.Common.Filter
{
    /// <summary>
    /// 分页查询结果类
    /// </summary>
    public class PagedQueryResult<T> where T : new()
    {
        private IList<T> data;
        /// <summary>
        /// 分页数据
        /// </summary>
        public IList<T> Data
        {
            get
            {
                if (data == null)
                    data = new List<T>();

                return data;
            }
            set
            {
                data = value;
            }
        }


        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get; set;
        }

        /// <summary>
        /// 总条数
        /// </summary>
        public int TotalCount
        {
            get; set;
        }

        /// <summary>
        /// 当前页索引，从0开始
        /// </summary>
        public int PageIndex
        {
            get; set;
        }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize
        {
            get; set;
        }
    }
}
