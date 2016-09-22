using Anchi.ERP.Domain.SystemConfigs;
using Anchi.ERP.IRepository.Configs;
using ServiceStack.OrmLite;
using System;

namespace Anchi.ERP.Repository.Configs
{
    /// <summary>
    /// 系统配置仓储实现
    /// </summary>
    public class ConfigRepository : BaseRepository<SystemConfig>, IConfigRepository
    {
        #region 根据标识获取配置
        /// <summary>
        /// 根据标识获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SystemConfig GetByKey(string key)
        {
            using (var context = DbContext.Open())
            {
                return context.Single<SystemConfig>(item => item.Key == key);
            }
        }
        #endregion

        #region 创建系统配置
        /// <summary>
        /// 创建系统配置
        /// </summary>
        /// <param name="model"></param>
        public override void Create(SystemConfig model)
        {
            if (GetByKey(model.Key) != null)
                throw new Exception(string.Format("配置Key重复：{0}", model.Key));

            base.Create(model);
        }
        #endregion
    }
}
