using Anchi.ERP.Common.Filter;
using Anchi.ERP.Data.IRespository;
using Anchi.ERP.Domain;
using System;
using SqliteSugar;
using System.Collections.Generic;

namespace Anchi.ERP.Data.Repository
{
    public class BaseRepository<T> : IBaseRespository<T> where T : BaseDomain, new()
    {
        #region 根据ID获取数据
        /// <summary>
        /// 根据ID获取数据
        ///     不加载关联数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual T Get(Guid Id)
        {
            using (var context = new AnchiDbContext())
            {
                return context.Queryable<T>().Where(item => item.Id == Id).FirstOrDefault();
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
            using (var context = new AnchiDbContext())
            {
                return context.Queryable<T>().Where(item => item.Id == Id).FirstOrDefault();
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
            using (var context = new AnchiDbContext())
            {
                context.Update(model);
            }
        }
        #endregion


        /// <summary>
        /// 修改数据
        ///     修改关联对象，基仓储不修改关联，由各子仓储类重写修改
        /// </summary>
        /// <param name="model"></param>
        public virtual void UpdateModel(T model)
        {
            using (var context = new AnchiDbContext())
            {
                context.Update(model);
            }
        }

        #region 创建数据
        /// <summary>
        /// 创建数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public virtual void Create(T model)
        {
            using (var context = new AnchiDbContext())
            {
                context.Insert(model, false);
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
            using (var context = new AnchiDbContext())
            {
                context.BeginTran();
                foreach (var Id in IdArray)
                {
                    context.Delete<T>(item => item.Id == Id);
                }
                context.CommitTran();
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
            var paramDict = filter.ParamDict;

            using (var context = new AnchiDbContext())
            {
                var pagedSql = string.Format("SELECT * FROM ({0}) temp LIMIT {1} OFFSET {2}",
                                        filter.SQL, filter.PageSize, filter.PageSize * filter.PageIndex);
                result.Data = context.SqlQuery<TModel>(pagedSql, paramDict);

                var countSql = string.Format("SELECT COUNT(1) FROM ({0}) AS temp", sql);
                result.TotalCount = context.GetInt(countSql, paramDict);
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
            var paramDict = filter.ParamDict;

            using (var context = new AnchiDbContext())
            {
                result = context.SqlQuery<TModel>(sql, paramDict);
            }

            return result;
        }
        #endregion
    }
}
