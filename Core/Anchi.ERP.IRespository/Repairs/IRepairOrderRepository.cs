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
    }
}
