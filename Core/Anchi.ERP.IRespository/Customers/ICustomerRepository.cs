using Anchi.ERP.Domain.Customers;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.Customers
{
    /// <summary>
    /// 客户管理仓储层接口
    /// </summary>
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
