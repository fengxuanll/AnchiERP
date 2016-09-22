using Anchi.ERP.Domain.SystemConfigs;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.Configs
{
    /// <summary>
    /// 系统配置仓储层接口
    /// </summary>
    public interface IConfigRepository : IBaseRepository<SystemConfig>
    {
    }
}
