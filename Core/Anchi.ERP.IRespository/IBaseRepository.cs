using Anchi.ERP.Common.Filter;
using System;
using System.Collections.Generic;

namespace Anchi.ERP.IRespository
{
    /// <summary>
    /// 仓储层接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRespository<T> where T : new()
    {
        /// <summary>
        /// 根据ID获取对象
        ///     不加载关联对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T Get(Guid Id);
        /// <summary>
        /// 根据ID获取对象
        ///     加载关联对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetModel(Guid Id);
        /// <summary>
        /// 创建数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Create(T model);
        /// <summary>
        /// 修改数据
        ///     不修改关联对象
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        void Update(T model);
        /// <summary>
        /// 修改数据
        ///     修改关联对象
        /// </summary>
        /// <param name="model"></param>
        void UpdateModel(T model);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="IdArray"></param>
        bool Delete(params Guid[] IdArray);
        /// <summary>
        /// 分页查找数据
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        PagedQueryResult<TModel> FindPaged<TModel>(PagedQueryFilter filter) where TModel : new();
        /// <summary>
        /// 不分页查找数据
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="filter"></param>
        /// <returns></returns>
        IList<TModel> Find<TModel>(QueryFilter filter) where TModel : new();
    }
}
