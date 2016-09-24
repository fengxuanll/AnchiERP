using Anchi.ERP.Domain.Finances;
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
        /// <summary>
        /// 取消销售单
        /// </summary>
        /// <param name="model"></param>
        /// <param name="order"></param>
        void Cancel(SaleOrder model, FinanceOrder order);
        /// <summary>
        /// 结算销售单
        /// </summary>
        /// <param name="model">销售单</param>
        /// <param name="order">财务单</param>
        void Settlement(SaleOrder model, FinanceOrder order);
        /// <summary>
        /// 生成销售单编码
        /// </summary>
        /// <returns></returns>
        string GetSequenceNextCode();
    }
}
