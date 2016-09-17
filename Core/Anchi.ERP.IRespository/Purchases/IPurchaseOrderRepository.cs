using Anchi.ERP.Domain.PurchaseOrders;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.Purchases
{
    /// <summary>
    /// 采购单仓储层接口
    /// </summary>
    public interface IPurchaseOrderRepository : IBaseRepository<PurchaseOrder>
    {
        /// <summary>
        /// 设置已到货
        /// </summary>
        /// <param name="model"></param>
        void SetArrival(PurchaseOrder model);
    }
}
