using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain;
using Anchi.ERP.IRespository;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.Repository
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseDomain, new()
    {
        public BaseRepository()
        {
            this.DbContext = new AnchiDbContext();
        }

        protected AnchiDbContext DbContext { get; }

        #region 根据ID获取数据
        /// <summary>
        /// 根据ID获取数据
        ///     不加载关联数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual T Get(Guid Id)
        {
            using (var context = DbContext.Open())
            {
                return context.SingleById<T>(Id);
            }
        }

        /// <summary>
        /// 根据ID获取数据
        ///     加载关联数据，基仓储类不关联，由各子仓储类取重写实现
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual T GetModel(Guid Id)
        {
            using (var context = DbContext.Open())
            {
                return context.SingleById<T>(Id);
            }
        }
        #endregion

        #region 修改数据
        /// <summary>
        /// 修改数据
        ///     不修改关联对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void Update(T model)
        {
            using (var context = DbContext.Open())
            {
                context.Update(model);
            }
        }

        /// <summary>
        /// 修改数据
        ///     修改关联对象，基仓储不修改关联，由各子仓储类重写修改
        /// </summary>
        /// <param name="model"></param>
        public virtual void UpdateModel(T model)
        {
            using (var context = DbContext.Open())
            {
                context.Update(model);
            }
        }
        #endregion

        #region 创建数据
        /// <summary>
        /// 创建数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void Create(T model)
        {
            using (var context = DbContext.Open())
            {
                context.Insert(model);
            }
        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="IdArray"></param>
        public virtual bool Delete(params Guid[] IdArray)
        {
            using (var context = DbContext.Open())
            {
                using (var tran = context.BeginTransaction())
                {
                    foreach (var Id in IdArray)
                    {
                        context.Delete<T>(item => item.Id == Id);
                    }
                    tran.Commit();
                }
            }
            return true;
        }
        #endregion

        #region 分页查找数据
        /// <summary>
        /// 分页查找数据
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public virtual PagedQueryResult<TModel> FindPaged<TModel>(PagedQueryFilter filter) where TModel : new()
        {
            var result = new PagedQueryResult<TModel>();

            var sql = filter.SQL;
            using (var context = DbContext.Open())
            {
                var pagedSql = string.Format("SELECT * FROM ({0}) temp LIMIT {1} OFFSET {2}",
                                        filter.SQL, filter.PageSize, filter.PageSize * filter.PageIndex);
                result.Data = context.SqlList<TModel>(pagedSql, filter.ParamDict);

                var countSql = string.Format("SELECT COUNT(1) FROM ({0}) AS temp", sql);
                result.TotalCount = context.SqlScalar<int>(countSql, filter.ParamDict);
            }

            result.PageIndex = filter.PageIndex;
            result.PageSize = filter.PageSize;
            result.TotalPage = result.TotalCount / filter.PageSize;
            if (result.TotalCount % result.PageSize > 0)
                result.TotalPage++;

            return result;
        }
        #endregion

        #region 不分页查找数据
        /// <summary>
        /// 不分页查找数据
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<TModel> Find<TModel>(QueryFilter filter) where TModel : new()
        {
            var result = new List<TModel>();

            var sql = filter.SQL;
            using (var context = DbContext.Open())
            {
                result = context.SqlList<TModel>(sql, filter.ParamDict);
            }

            return result;
        }
        #endregion
    }
}
