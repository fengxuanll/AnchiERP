using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Finances;
using Anchi.ERP.IRepository.Finances;
using Anchi.ERP.Repository.Finances;
using Anchi.ERP.ServiceModel.Finances;
using System.Collections.Generic;

namespace Anchi.ERP.Service.Finances
{
    /// <summary>
    /// 财务单服务层实现
    /// </summary>
    public class FinanceOrderService : BaseService<FinanceOrder>
    {
        #region 构造函数和属性
        public FinanceOrderService() : this(new FinanceOrderRepository())
        {
        }

        public FinanceOrderService(IFinanceOrderRepository financeOrderRepository) : base(financeOrderRepository)
        {
            this.FinanceOrderRepository = financeOrderRepository;
        }

        IFinanceOrderRepository FinanceOrderRepository
        {
            get;
        }
        #endregion

        #region 分页查找财务记录
        /// <summary>
        /// 分页查找财务记录
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PagedQueryResult<FinanceOrderModel> FindList(PagedQueryFilter filter)
        {
            var result = base.FindPaged(filter);

            var response = new PagedQueryResult<FinanceOrderModel>();
            foreach (var item in result.Data)
            {
                var model = new FinanceOrderModel();
                model.Id = item.Id;
                model.Type = item.Type;
                model.RelationId = item.RelationId;
                model.Amount = item.Amount;
                model.Remark = item.Remark;
                model.CreatedOn = item.CreatedOn;
                response.Data.Add(model);
            }
            response.PageIndex = result.PageIndex;
            response.PageSize = result.PageSize;
            response.TotalCount = result.TotalCount;
            response.TotalPage = result.TotalPage;
            return response;
        }
        #endregion
    }
}
