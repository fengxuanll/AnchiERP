using Anchi.ERP.Domain.Finances;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.Finances
{
    /// <summary>
    /// 财务单仓储层接口
    /// </summary>
    public interface IFinanceOrderRepository : IBaseRepository<FinanceOrder>
    {
        /// <summary>
        /// 生成财务单编码
        /// </summary>
        /// <returns></returns>
        string GetSequenceNextCode();
    }
}
