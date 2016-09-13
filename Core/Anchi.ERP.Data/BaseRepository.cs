using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain;
using Anchi.ERP.Domain.Common;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Sqlite;
using System;
using System.Configuration;

namespace Anchi.ERP.Data
{
    public class BaseRepository<T> where T : BaseDomain, new()
    {
        #region 构造函数和属性
        private string _connectionString;
        private string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                    _connectionString = ConfigurationManager.ConnectionStrings["AnchiERP"].ConnectionString;
                return _connectionString;
            }
        }

        private IDbConnectionFactory dbFactory;
        protected IDbConnectionFactory DbFactory
        {
            get
            {
                if (dbFactory == null)
                    dbFactory = new OrmLiteConnectionFactory(ConnectionString, SqliteOrmLiteDialectProvider.Instance);

                return dbFactory;
            }
        }

        public BaseRepository()
        {
            using (var db = DbFactory.Open())
            {
                db.CreateTableIfNotExists<T>();
            }
        }
        #endregion

        #region 新增数据
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void Create(T model)
        {
            using (var db = DbFactory.Open())
            {
                db.Insert(model);
            }
        }
        #endregion

        #region 修改数据
        /// <summary>
        /// 修改数据
        ///     如果需要同时修改关联对象，请重新该方法
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Update(T model)
        {
            using (var db = DbFactory.Open())
            {
                return db.Update(model);
            }
        }

        /// <summary>
        /// 修改数据
        ///     仅修改当前对象，不修改关联对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateModel(T model)
        {
            using (var db = DbFactory.Open())
            {
                return db.Update(model);
            }
        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual int Delete(T model)
        {
            using (var db = DbFactory.Open())
            {
                return db.Delete(model);
            }
        }
        #endregion

        #region 批量删除数据
        /// <summary>
        /// 批量删除数据
        /// </summary>
        /// <param name="Ids"></param>
        public virtual void DeleteList(params Guid[] Ids)
        {
            using (var db = DbFactory.Open())
            {
                db.DeleteByIds<T>(Ids);
            }
        }
        #endregion

        #region 根据ID获取数据
        /// <summary>
        /// 根据ID获取数据
        ///     如果有关联对象，请重写该方法并关联对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual T GetById(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                return db.SingleById<T>(Id);
            }
        }

        /// <summary>
        /// 根据ID获取对象
        ///     该方法只获取当前对象，不关联对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetModel(Guid Id)
        {
            using (var db = DbFactory.Open())
            {
                return db.SingleById<T>(Id);
            }
        }
        #endregion

        #region 分页查询列表
        /// <summary>
        /// 分页查询列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PagedResult<T> Find(PagedFilter filter)
        {
            var result = new PagedResult<T>();
            using (var db = DbFactory.Open())
            {
                var sqlExpression = OrmLiteConfig.DialectProvider.SqlExpression<T>();
                sqlExpression.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize);

                result.Data = db.Select(sqlExpression);
                result.TotalCount = (int)db.Count<T>();
            }

            result.PageIndex = filter.PageIndex;
            result.PageSize = filter.PageSize;
            result.TotalPage = result.TotalCount / filter.PageSize;
            if (result.TotalCount % result.PageSize > 0)
                result.TotalPage++;

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
            using (var db = DbFactory.Open())
            {
                var sql = filter.SQL;

                var pagedSql = string.Format("SELECT * FROM ({0}) temp LIMIT {1} OFFSET {2}",
                                        filter.SQL, filter.PageSize, filter.PageSize * filter.PageIndex);
                result.Data = db.SqlList<TModel>(pagedSql, filter.ParamDict);

                var countSql = string.Format("SELECT COUNT(1) FROM ({0}) AS temp", sql);
                result.TotalCount = db.SqlScalar<int>(countSql, filter.ParamDict);
            }

            result.PageIndex = filter.PageIndex;
            result.PageSize = filter.PageSize;
            result.TotalPage = result.TotalCount / filter.PageSize;
            if (result.TotalCount % result.PageSize > 0)
                result.TotalPage++;

            return result;
        }
        #endregion
    }
}
