using Anchi.ERP.Domain.SystemConfigs;
using Anchi.ERP.IRepository.Configs;

namespace Anchi.ERP.Repository.Configs
{
    /// <summary>
    /// 系统配置仓储实现
    /// </summary>
    public class ConfigRepository : BaseRepository<SystemConfig>, IConfigRepository
    {
    }
}
