using Anchi.ERP.Domain.Finances;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.Repairs
{
    /// <summary>
    /// 维修单仓储层接口
    /// </summary>
    public interface IRepairOrderRepository : IBaseRepository<RepairOrder>
    {
        /// <summary>
        /// 设置已完工
        /// </summary>
        /// <param name="model"></param>
        void Complete(RepairOrder model);
        /// <summary>
        /// 反结算维修单
        /// </summary>
        /// <param name="model"></param>
        void Cancel(RepairOrder model);
        /// <summary>
        /// 结算维修单
        /// </summary>
        /// <param name="model">维修单</param>
        /// <param name="order">财务单</param>
        void Settlement(RepairOrder model, FinanceOrder order);
    }
}
