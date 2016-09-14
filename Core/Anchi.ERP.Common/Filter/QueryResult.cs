using System.Collections.Generic;

namespace Anchi.ERP.Common.Filter
{
    /// <summary>
    /// 查询结果类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class QueryResult<T> : List<T> where T : new()
    {

    }
}
