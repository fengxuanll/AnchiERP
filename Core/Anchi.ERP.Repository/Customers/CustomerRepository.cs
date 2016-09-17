using Anchi.ERP.Domain.Customers;
using Anchi.ERP.IRepository.Customers;

namespace Anchi.ERP.Repository.Customers
{
    /// <summary>
    /// 客户仓储类
    /// </summary>
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
    }
}
