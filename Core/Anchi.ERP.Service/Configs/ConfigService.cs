using Anchi.ERP.Domain.SystemConfigs;
using Anchi.ERP.IRepository.Configs;
using Anchi.ERP.Repository.Configs;

namespace Anchi.ERP.Service.Configs
{
    /// <summary>
    /// 系统配置服务层
    /// </summary>
    public class ConfigService : BaseService<SystemConfig>
    {
        #region 构造函数和属性
        public ConfigService() : this(new ConfigRepository()) { }

        public ConfigService(IConfigRepository configRepository) : base(configRepository)
        {
            this.ConfigRepository = configRepository;
        }

        IConfigRepository ConfigRepository
        {
            get;
        }
        #endregion

        #region 根据标识获取配置
        /// <summary>
        /// 根据标识获取配置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SystemConfig GetByKey(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                return null;

            return ConfigRepository.GetByKey(key);
        }
        #endregion
    }
}
