using Anchi.ERP.Domain.Finances;
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
        /// <summary>
        /// 反结算采购单
        /// </summary>
        /// <param name="model"></param>
        void Cancel(PurchaseOrder model);
        /// <summary>
        /// 结算采购单
        /// </summary>
        /// <param name="model">采购单</param>
        /// <param name="order">财务单</param>
        void Settlement(PurchaseOrder model, FinanceOrder order);
    }
}
