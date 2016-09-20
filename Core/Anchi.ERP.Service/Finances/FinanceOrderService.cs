using Anchi.ERP.Domain.Finances;
using Anchi.ERP.IRepository.Finances;
using Anchi.ERP.Repository.Finances;

namespace Anchi.ERP.Service.Finances
{
    /// <summary>
    /// 财务单服务层实现
    /// </summary>
    public class FinanceOrderService : BaseService<FinanceOrder>
    {
        #region 构造函数和属性
        public FinanceOrderService() : this(new FinanceOrderRepository())
        { }

        public FinanceOrderService(IFinanceOrderRepository financeOrderRepository) : base(financeOrderRepository)
        {
            this.FinanceOrderRepository = financeOrderRepository;
        }

        IFinanceOrderRepository FinanceOrderRepository { get; }
        #endregion
    }
}
