using Anchi.ERP.Data;
using Anchi.ERP.Domain;
using Anchi.ERP.Domain.Common;
using System;

namespace Anchi.ERP.Service
{
    /// <summary>
    /// 服务层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> where T : BaseDomain, new()
    {
        #region 构造函数和属性
        public BaseService(BaseRepository<T> repository)
        {
            this.Repository = repository;
        }
        BaseRepository<T> Repository
        {
            get;
        }
        #endregion

        #region 根据ID获取
        /// <summary>
        /// 根据ID获取，关联其它对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetById(Guid Id)
        {
            if (Id == Guid.Empty)
                return null;

            return Repository.GetById(Id);
        }

        /// <summary>
        /// 根据ID获取对象，不关联其它对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetModel(Guid Id)
        {
            if (Id == Guid.Empty)
                return null;

            return Repository.GetModel(Id);
        }
        #endregion

        #region 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="Ids"></param>
        public void DeleteList(params Guid[] Ids)
        {
            if (Ids.Length == 0)
                return;

            Repository.DeleteList(Ids);
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
            if (filter == null)
                return new PagedResult<T>();

            if (filter.PageSize == 0)
                return new PagedResult<T>();

            return Repository.Find(filter);
        }
        #endregion
    }
}
