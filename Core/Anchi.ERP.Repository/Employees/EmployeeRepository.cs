using Anchi.ERP.Domain.Employees;
using Anchi.ERP.IRepository.Employees;

namespace Anchi.ERP.Repository.Employees
{
    /// <summary>
    /// 员工仓储类
    /// </summary>
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
    }
}
