using System.Collections.Generic;

namespace Anchi.ERP.Domain.Common
{
    /// <summary>
    /// 分页查询结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedResult<T> where T : new()
    {
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

        private IList<T> data;
        /// <summary>
        /// 当前页数据
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
    }
}
