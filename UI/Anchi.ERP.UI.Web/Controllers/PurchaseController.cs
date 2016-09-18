using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.PurchaseOrders;
using Anchi.ERP.Domain.PurchaseOrders.Filter;
using Anchi.ERP.Service.Employees;
using Anchi.ERP.Service.Purchases;
using Anchi.ERP.Service.Suppliers;
using Anchi.ERP.ServiceModel.Purchases;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 采购管理
    /// </summary>
    [UserAuthorize]
    public class PurchaseController : BaseController
    {
        #region 构造函数和属性
        public PurchaseController() : this(new PurchaseService(), new EmployeeService(), new SupplierService()) { }

        public PurchaseController(PurchaseService purchaseService, EmployeeService employeeService, SupplierService supplierService)
        {
            this.PurchaseService = purchaseService;
            this.EmployeeService = employeeService;
            this.SupplierService = supplierService;
        }

        PurchaseService PurchaseService { get; }
        EmployeeService EmployeeService { get; }
        SupplierService SupplierService { get; }
        #endregion

        #region 添加采购单
        /// <summary>
        /// 添加采购单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.EmployeeList = EmployeeService.FindNormalList();

            var model = new PurchaseOrder();
            model.PurchaseOn = DateTime.Now;
            return View("Edit", model);
        }
        #endregion

        #region 采购单管理
        /// <summary>
        /// 采购单管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            ViewBag.EmployeeList = EmployeeService.FindNormalList();
            return View("Index");
        }

        /// <summary>
        /// 查询维修项目列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(FindPurchaseOrderFilter filter)
        {
            var modelList = new List<PurchaseOrderModel>();
            var result = PurchaseService.FindPaged(filter);
            foreach (var item in result.Data)
            {
                var purchaseBy = EmployeeService.Get(item.PurchaseById);
                var supplier = SupplierService.Get(item.SupplierId);
                modelList.Add(new PurchaseOrderModel
                {
                    Id = item.Id,
                    Amount = item.Amount,
                    PurchaseByName = purchaseBy == null ? string.Empty : purchaseBy.Name,
                    PurchaseOn = item.PurchaseOn,
                    Remark = item.Remark,
                    SettlementAmount = item.SettlementAmount,
                    SettlementOn = item.SettlementOn,
                    SettlementRemark = item.SettlementRemark,
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
            return new BetterJsonResult(response, true);
        }
        #endregion

        #region 修改采购单
        /// <summary>
        /// 修改采购单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ViewBag.EmployeeList = EmployeeService.FindNormalList();

            var model = PurchaseService.Get(id);
            return View("Edit", model);
        }

        /// <summary>
        /// 获取采购单详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetEditModel(Guid Id)
        {
            var model = PurchaseService.GetModel(Id);
            return new BetterJsonResult(model, true);
        }
        #endregion

        #region 保存采购单
        /// <summary>
        /// 保存采购单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Save(PurchaseOrder model)
        {
            try
            {
                if (model.Id == Guid.Empty)
                    model.CreatedById = base.CurrentUser.Id;

                PurchaseService.SaveOrUpdate(model);
                return new BetterJsonResult();
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 结算采购单
        /// <summary>
        /// 结算采购单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Settlement()
        {
            return View();
        }

        /// <summary>
        /// 采购结算
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SettlementOrder(PurchaseSettlementModel model)
        {
            try
            {
                PurchaseService.Settlement(model);
                return new BetterJsonResult();
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 设置已到货
        /// <summary>
        /// 设置已到货
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ActionResult SetArrival(IList<Guid> idList)
        {
            try
            {
                PurchaseService.SetArrival(idList);
                return new BetterJsonResult();
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion
    }
}