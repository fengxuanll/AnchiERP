using Anchi.ERP.Domain.SaleOrders;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.SaleOrders
{
    /// <summary>
    /// 销售单仓储层接口
    /// </summary>
    public interface ISaleOrderRepository : IBaseRepository<SaleOrder>
    {
        /// <summary>
        /// 销售单出库
        /// </summary>
        /// <param name="model"></param>
        void Outbound(SaleOrder model);
    }
}
