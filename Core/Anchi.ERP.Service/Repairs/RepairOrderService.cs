using Anchi.ERP.Common;
using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Finances;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Domain.RepairOrders.Enum;
using Anchi.ERP.Domain.RepairOrders.Filter;
using Anchi.ERP.IRepository.Finances;
using Anchi.ERP.IRepository.Repairs;
using Anchi.ERP.Repository.Finances;
using Anchi.ERP.Repository.Repairs;
using Anchi.ERP.Service.Customers;
using Anchi.ERP.Service.Employees;
using Anchi.ERP.ServiceModel.Repairs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Service.Repairs
{
    /// <summary>
    /// 维修单服务类
    /// </summary>
    public class RepairOrderService : BaseService<RepairOrder>
    {
        #region 构造函数和属性
        public RepairOrderService() : this(new RepairOrderRepository(), new CustomerService(), new EmployeeService(), new FinanceOrderRepository()) { }

        public RepairOrderService(IRepairOrderRepository repairOrderRepository, CustomerService customerService, EmployeeService employeeService, IFinanceOrderRepository financeOrderRepository) : base(repairOrderRepository)
        {
            this.RepairOrderRepository = repairOrderRepository;
            this.CustomerService = customerService;
            this.EmployeeService = employeeService;
            this.FinanceOrderRepository = financeOrderRepository;
        }

        IRepairOrderRepository RepairOrderRepository
        {
            get;
        }

        IFinanceOrderRepository FinanceOrderRepository
        {
            get;
        }

        CustomerService CustomerService
        {
            get;
        }

        EmployeeService EmployeeService
        {
            get;
        }
        #endregion

        #region 保存维修单
        /// <summary>
        /// 保存维修单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RepairOrder SaveOrUpdate(RepairOrder model)
        {
            if (model.CustomerId == Guid.Empty)
                throw new Exception("请选择客户。");

            if (model.RepairOn <= SqlDateTime.Min)
                throw new Exception("请选择开单日期。");

            if (model.ReceptionById == Guid.Empty)
                throw new Exception("请选择接待人。");

            if (!model.ProjectList.Any() && !model.ProductList.Any())
                throw new Exception("请选择维修项目和配件明细。");

            if (model.ProjectList.Any(item => item.Quantity == 0))
                throw new Exception("请填写维修项目的数量");

            if (model.ProjectList.Any(item => item.EmployeeId == Guid.Empty))
                throw new Exception("请选择维修项目的维修人。");

            if (model.ProductList.Any(item => item.Quantity == 0))
                throw new Exception("请填写配件明细的数量");

            model.Amount = model.ProjectList.Sum(item => item.UnitPrice * item.Quantity) + model.ProductList.Sum(item => item.UnitPrice * item.Quantity);

            var temp = GetModel(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.Code = RepairOrderRepository.GetSequenceNextCode();
                model.Status = EnumRepairOrderStatus.Repairing;
                model.SettlementStatus = EnumSettlementStatus.Waiting;
                model.CreatedOn = DateTime.Now;

                this.RepairOrderRepository.Create(model);
            }
            else
            {
                if (temp.Status != EnumRepairOrderStatus.Repairing)
                    throw new Exception("只能修改维修中的维修单。");

                temp.Amount = model.Amount;
                temp.RepairOn = model.RepairOn;
                temp.ReceptionById = model.ReceptionById;
                temp.CustomerId = model.CustomerId;
                temp.ProductList = model.ProductList;
                temp.ProjectList = model.ProjectList;

                this.RepairOrderRepository.UpdateModel(temp);
            }
            return model;
        }
        #endregion

        #region 设为已完工
        /// <summary>
        /// 设为已完工
        /// </summary>
        /// <param name="IdList"></param>
        public void SetComplete(IList<Guid> IdList)
        {
            if (IdList == null || !IdList.Any())
                return;

            foreach (var Id in IdList)
            {
                var model = GetModel(Id);
                if (model == null)
                    return;

                if (model.Status != EnumRepairOrderStatus.Repairing)
                    throw new Exception("只能将维修中的维修单设置为已完工。");

                this.RepairOrderRepository.Complete(model);
            }
        }
        #endregion

        #region 结算维修单
        /// <summary>
        /// 结算维修单
        /// </summary>
        /// <param name="model"></param>
        public void Settlement(RepairSettlementModel model)
        {
            if (model == null)
                return;

            if (model.SettlementAmount <= 0)
                throw new Exception("请输入结算金额。");

            var order = Get(model.RepairOrderId);
            if (order == null)
                throw new Exception("维修单不存在。");

            if (order.Status != EnumRepairOrderStatus.Completed)
                throw new Exception("只能结算已完工的维修单。");

            if (order.SettlementStatus == EnumSettlementStatus.Completed)
                throw new Exception("只能结算未结算的维修单。");

            order.SettlementStatus = model.SettlementStatus;
            order.SettlementAmount = order.SettlementAmount + model.SettlementAmount;

            if (order.SettlementAmount >= order.Amount && order.SettlementStatus == EnumSettlementStatus.PartCompleted)
                throw new Exception("结算金额已超过维修单总金额，不允许部分结算。");

            var financeOrder = new FinanceOrder();
            financeOrder.Code = this.FinanceOrderRepository.GetSequenceNextCode();
            financeOrder.Amount = model.SettlementAmount;
            financeOrder.Remark = model.SettlementRemark;

            this.RepairOrderRepository.Settlement(order, financeOrder);
        }
        #endregion

        #region 取消维修单
        /// <summary>
        /// 取消维修单
        /// </summary>
        /// <param name="idList"></param>
        public void CancelOrder(IList<Guid> idList)
        {
            if (idList == null || !idList.Any())
                return;

            foreach (var Id in idList)
            {
                var model = GetModel(Id);
                if (model == null)
                    continue;

                var order = new FinanceOrder();
                order.Code = this.FinanceOrderRepository.GetSequenceNextCode();

                this.RepairOrderRepository.Cancel(model, order);
            }
        }
        #endregion

        #region 分页查找维修单列表
        /// <summary>
        /// 分页查找维修单列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PagedQueryResult<RepairOrderModel> FindList(FindRepairOrderFilter filter)
        {
            var modelList = new List<RepairOrderModel>();

            var result = this.FindPaged(filter);
            foreach (var item in result.Data)
            {
                var customer = this.CustomerService.Get(item.CustomerId);
                var receptionBy = this.EmployeeService.Get(item.ReceptionById);
                modelList.Add(new RepairOrderModel
                {
                    Id = item.Id,
                    Code = item.Code,
                    Amount = item.Amount,
                    CompleteOn = item.CompleteOn,
                    Remark = item.Remark,
                    RepairOn = item.RepairOn,
                    SettlementOn = item.SettlementOn,
                    SettlementStatus = item.SettlementStatus,
                    SettlementAmount = item.SettlementAmount,
                    Status = item.Status,
                    CarNumber = customer == null ? string.Empty : customer.CarNumber,
                    CustomerName = customer == null ? string.Empty : customer.Name,
                    ReceptionByName = receptionBy == null ? string.Empty : receptionBy.Name,
                });
            }

            var response = new PagedQueryResult<RepairOrderModel>();
            response.Data = modelList;
            response.PageIndex = result.PageIndex;
            response.PageSize = result.PageSize;
            response.TotalCount = result.TotalCount;
            response.TotalPage = result.TotalPage;

            return response;
        }
        #endregion
    }
}
