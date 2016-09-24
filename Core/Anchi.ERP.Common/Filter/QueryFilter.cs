using Anchi.ERP.Common.Filter.Enum;
using System.Collections.Generic;

namespace Anchi.ERP.Common.Filter
{
    /// <summary>
    /// 查询筛选器
    /// </summary>
    public abstract class QueryFilter
    {
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public abstract string SQL
        {
            get;
        }

        /// <summary>
        /// 排序字段
        /// </summary>
        public virtual string OrderBy
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

        private IDictionary<string, object> paramDict;
        /// <summary>
        /// 参数字典
        /// </summary>
        public IDictionary<string, object> ParamDict
        {
            get
            {
                if (paramDict == null)
                    paramDict = new Dictionary<string, object>();

                return paramDict;
            }
        }
    }
}
