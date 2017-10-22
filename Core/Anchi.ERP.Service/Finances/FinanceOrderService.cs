using Anchi.ERP.Common.Extensions;
using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Finances;
using Anchi.ERP.Domain.Finances.Enum;
using Anchi.ERP.IRepository.Finances;
using Anchi.ERP.Repository.Finances;
using Anchi.ERP.Service.Purchases;
using Anchi.ERP.Service.Repairs;
using Anchi.ERP.Service.SaleOrders;
using Anchi.ERP.ServiceModel.Finances;

namespace Anchi.ERP.Service.Finances
{
    /// <summary>
    /// 财务单服务层实现
    /// </summary>
    public class FinanceOrderService : BaseService<FinanceOrder>
    {
        #region 构造函数和属性
        public FinanceOrderService(
            IFinanceOrderRepository financeOrderRepository,
            PurchaseService purchaseService,
            RepairOrderService repairOrderService,
            SaleOrderService saleOrderService) : base(financeOrderRepository)
        {
            this.FinanceOrderRepository = financeOrderRepository;
            this.PurchaseService = purchaseService;
            this.RepairOrderService = repairOrderService;
            this.SaleOrderService = saleOrderService;
        }

        IFinanceOrderRepository FinanceOrderRepository
        {
            get;
        }

        PurchaseService PurchaseService
        {
            get;
        }

        RepairOrderService RepairOrderService
        {
            get;
        }

        SaleOrderService SaleOrderService
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
                model.Code = item.Code;
                model.Type = item.Type;
                model.RelationId = item.RelationId;
                model.Amount = item.Type.GetDisplayGroupName() == "Receipt" ? item.Amount : 0 - item.Amount;
                model.Remark = item.Remark;
                model.CreatedOn = item.CreatedOn;

                switch (item.Type)
                {
                    case EnumFinanceOrderType.Purchase:
                        var purchaseOrder = PurchaseService.Get(item.RelationId);
                        model.RelationCode = purchaseOrder == null ? null : purchaseOrder.Code;
                        break;
                    case EnumFinanceOrderType.Repair:
                        var repairOrder = RepairOrderService.Get(item.RelationId);
                        model.RelationCode = repairOrder == null ? null : repairOrder.Code;
                        break;
                    case EnumFinanceOrderType.Sale:
                        var saleOrder = SaleOrderService.Get(item.RelationId);
                        model.RelationCode = saleOrder == null ? null : saleOrder.Code;
                        break;
                }

                response.Data.Add(model);
            }
            response.PageIndex = result.PageIndex;
            response.PageSize = result.PageSize;
            response.TotalCount = result.TotalCount;
            response.TotalPage = result.TotalPage;
            return response;
        }
        #endregion

        #region 新建财务单
        /// <summary>
        /// 新建财务单
        /// </summary>
        /// <param name="model"></param>
        public override void Create(FinanceOrder model)
        {
            model.Code = this.FinanceOrderRepository.GetSequenceNextCode();
            base.Create(model);
        }
        #endregion
    }
}
