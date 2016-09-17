using Anchi.ERP.Domain.Users;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.Users
{
    /// <summary>
    /// 用户管理仓储层接口
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
