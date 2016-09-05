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
        #endregion

        #region 查询维修项目列表
        /// <summary>
        /// 查询维修项目列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PagedResult<T> Find(PagedFilter filter)
        {
            var result = new PagedResult<T>();
            using (var db = DbFactory.Open())
            {
                var ev = OrmLiteConfig.DialectProvider.SqlExpression<T>();
                ev.Skip(filter.PageIndex * filter.PageSize).Take(filter.PageSize);

                result.Data = db.Select(ev);
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
    }
}
