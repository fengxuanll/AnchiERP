using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Finances;
using Anchi.ERP.Domain.PurchaseOrders;
using Anchi.ERP.Domain.PurchaseOrders.Enum;
using Anchi.ERP.Domain.PurchaseOrders.Filter;
using Anchi.ERP.Domain.RepairOrders.Enum;
using Anchi.ERP.IRepository.Finances;
using Anchi.ERP.IRepository.Purchases;
using Anchi.ERP.Repository.Finances;
using Anchi.ERP.Repository.Purchases;
using Anchi.ERP.Service.Employees;
using Anchi.ERP.Service.Suppliers;
using Anchi.ERP.ServiceModel.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Anchi.ERP.Service.Purchases
{
    /// <summary>
    /// 采购管理服务类
    /// </summary>
    public class PurchaseService : BaseService<PurchaseOrder>
    {
        #region 构造函数和属性
        public PurchaseService() : this(new PurchaseOrderRepository(), new EmployeeService(), new SupplierService(), new FinanceOrderRepository()) { }

        public PurchaseService(IPurchaseOrderRepository purchaseOrderRepository, EmployeeService employeeService, SupplierService supplierService, IFinanceOrderRepository financeOrderRepository) : base(purchaseOrderRepository)
        {
            this.PurchaseOrderRepository = purchaseOrderRepository;
            this.EmployeeService = employeeService;
            this.SupplierService = supplierService;
            this.FinanceOrderRepository = financeOrderRepository;
        }

        IPurchaseOrderRepository PurchaseOrderRepository
        {
            get;
        }

        IFinanceOrderRepository FinanceOrderRepository
        {
            get;
        }

        EmployeeService EmployeeService
        {
            get;
        }

        SupplierService SupplierService
        {
            get;
        }
        #endregion

        #region 保存采购单
        /// <summary>
        /// 保存采购单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PurchaseOrder SaveOrUpdate(PurchaseOrder model)
        {
            if (model.SupplierId == Guid.Empty)
                throw new Exception("请选择供应商。");

            if (model.PurchaseById == Guid.Empty)
                throw new Exception("请选择采购人。");

            if (!model.ProductList.Any())
                throw new Exception("请选择采购配件。");

            if (model.ProductList.Any(item => item.Quantity == 0))
                throw new Exception("请填写采购配件的数量。");

            model.Amount = model.ProductList.Sum(item => item.UnitPrice * item.Quantity);

            var temp = PurchaseOrderRepository.GetModel(model.Id);
            if (temp == null)
            {
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.Code = this.PurchaseOrderRepository.GetSequenceNextCode();
                model.CreatedOn = DateTime.Now;
                model.Status = EnumPurchaseOrderStatus.Purchasing;
                model.SettlementStatus = EnumSettlementStatus.Waiting;

                this.PurchaseOrderRepository.Create(model);
            }
            else
            {
                if (temp.Status != EnumPurchaseOrderStatus.Purchasing)
                    throw new Exception("只能修改采购中的采购单。");

                temp.SupplierId = model.SupplierId;
                temp.PurchaseById = model.PurchaseById;
                temp.Amount = model.Amount;
                temp.PurchaseOn = model.PurchaseOn;
                temp.Remark = model.Remark;
                temp.ProductList = model.ProductList;

                this.PurchaseOrderRepository.UpdateModel(temp);
            }

            return model;
        }
        #endregion

        #region 结算采购单
        /// <summary>
        /// 结算采购单
        /// </summary>
        /// <param name="model"></param>
        public void Settlement(PurchaseSettlementModel model)
        {
            if (model == null)
                return;

            if (model.SettlementAmount <= 0)
                throw new Exception("请填写结算金额。");

            var order = PurchaseOrderRepository.GetModel(model.PurchaseOrderId);
            if (order == null)
                throw new Exception("采购单不存在。");

            if (order.Status != EnumPurchaseOrderStatus.Completed)
                throw new Exception("只能结算已全部到货的采购单。");

            if (order.SettlementStatus != EnumSettlementStatus.Waiting && order.SettlementStatus != EnumSettlementStatus.PartCompleted)
                throw new Exception("只能结算待结算的采购单。");

            order.SettlementStatus = model.SettlementStatus;
            order.SettlementAmount = order.SettlementAmount + model.SettlementAmount;

            var financeOrder = new FinanceOrder();
            order.Code = this.FinanceOrderRepository.GetSequenceNextCode();
            financeOrder.Amount = model.SettlementAmount;
            financeOrder.Remark = model.SettlementRemark;

            this.PurchaseOrderRepository.Settlement(order, financeOrder);
        }
        #endregion

        #region 设置已到货
        /// <summary>
        /// 设置已到货
        /// </summary>
        /// <param name="Id"></param>
        public void SetArrival(IList<Guid> IdList)
        {
            if (IdList == null || !IdList.Any())
                return;

            foreach (var Id in IdList)
            {
                var order = PurchaseOrderRepository.GetModel(Id);
                if (order == null)
                    continue;

                if (order.Status != EnumPurchaseOrderStatus.Purchasing)
                    throw new Exception("只能将采购中的采购单设置为已到货。");

                this.PurchaseOrderRepository.SetArrival(order);
            }
        }
        #endregion

        #region 取消采购单
        /// <summary>
        /// 取消采购单
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

                this.PurchaseOrderRepository.Cancel(model);
            }
        }
        #endregion

        #region 分页查找采购单列表
        /// <summary>
        /// 分页查找采购单列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public PagedQueryResult<PurchaseOrderModel> FindList(FindPurchaseOrderFilter filter)
        {
            var modelList = new List<PurchaseOrderModel>();
            var result = this.FindPaged(filter);
            foreach (var item in result.Data)
            {
                var purchaseBy = this.EmployeeService.Get(item.PurchaseById);
                var supplier = this.SupplierService.Get(item.SupplierId);
                modelList.Add(new PurchaseOrderModel
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    PurchaseByName = purchaseBy == null ? string.Empty : purchaseBy.Name,
                    PurchaseOn = item.PurchaseOn,
                    Remark = item.Remark,
                    SettlementAmount = item.SettlementAmount,
                    SettlementOn = item.SettlementOn,
                    SettlementStatus = item.SettlementStatus,
                    Status = item.Status,
                    SupplierName = supplier == null ? string.Empty : supplier.CompanyName,
                });
            }

            var response = new PagedQueryResult<PurchaseOrderModel>();
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
