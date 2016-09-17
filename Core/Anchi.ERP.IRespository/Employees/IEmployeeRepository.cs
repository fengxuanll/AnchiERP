using Anchi.ERP.Domain.Employees;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.Employees
{
    /// <summary>
    /// 客户管理仓储层接口
    /// </summary>
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
    }
}
