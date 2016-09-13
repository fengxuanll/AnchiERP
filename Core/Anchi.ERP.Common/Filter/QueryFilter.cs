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
