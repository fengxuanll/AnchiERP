using Anchi.ERP.Data;
using Anchi.ERP.Domain;
using Anchi.ERP.Domain.Common;
using System;

namespace Anchi.ERP.Service
{
    public class BaseService<T> where T : BaseDomain, new()
    {
        protected BaseRepository<T> Repository
        {
            get; set;
        }

        #region 根据ID获取
        /// <summary>
        /// 根据ID获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetById(Guid Id)
        {
            if (Id == Guid.Empty)
                return null;

            return Repository.GetById(Id);
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
