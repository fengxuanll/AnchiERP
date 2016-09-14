using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain;
using Chloe;
using Chloe.SQLite;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Anchi.ERP.Data.Chloe
{
    /// <summary>
    /// 仓储层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> where T : BaseDomain, new()
    {
        #region 数据库连接字符串
        private string _connectString;
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public string ConnectString
        {
            get
            {
                if (_connectString == null)
                    _connectString = ConfigurationManager.ConnectionStrings["AnchiERP"].ConnectionString;

                return _connectString;
            }
        }
        #endregion

        #region 筛选查询列表
        /// <summary>
        /// 筛选查询列表
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public QueryResult<TModel> Find<TModel>(QueryFilter filter) where TModel : new()
        {
            var result = new QueryResult<TModel>();

            var sql = filter.SQL;
            var paramArray = ParamDictToArray(filter.ParamDict);

            using (var context = new SQLiteContext(new AnchiConnectionFactory(ConnectString)))
            {
                var modelList = context.SqlQuery<TModel>(sql, paramArray);
                result.AddRange(modelList);
            }

            return result;
        }
        #endregion

        #region 分页筛选查询列表
        /// <summary>
        /// 分页筛选查询列表
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PagedQueryResult<TModel> FindPaged<TModel>(PagedQueryFilter filter) where TModel : new()
        {
            var result = new PagedQueryResult<TModel>();

            var sql = filter.SQL;
            var paramArray = ParamDictToArray(filter.ParamDict);

            using (var context = new SQLiteContext(new AnchiConnectionFactory(ConnectString)))
            {
                var pagedSql = string.Format("SELECT * FROM ({0}) temp LIMIT {1} OFFSET {2}",
                                        filter.SQL, filter.PageSize, filter.PageSize * filter.PageIndex);
                result.Data = context.SqlQuery<TModel>(pagedSql, paramArray).ToList();

                var countSql = string.Format("SELECT COUNT(1) FROM ({0}) AS temp", sql);
                result.TotalCount = context.SqlQuery<int>(countSql, paramArray).FirstOrDefault();
            }

            result.PageIndex = filter.PageIndex;
            result.PageSize = filter.PageSize;
            result.TotalPage = result.TotalCount / filter.PageSize;
            if (result.TotalCount % result.PageSize > 0)
                result.TotalPage++;

            return result;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 转换参数字典为Chloe参数数组
        /// </summary>
        /// <param name="paramDict"></param>
        /// <returns></returns>
        private static DbParam[] ParamDictToArray(IDictionary<string, object> paramDict)
        {
            var paramList = new List<DbParam>();
            foreach (var item in paramDict)
            {
                var param = DbParam.Create(item.Key, item.Value);
                paramList.Add(param);
            }
            return paramList.ToArray();
        }
        #endregion
    }
}
