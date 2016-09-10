using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.PurchaseOrders;
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
            return View("Index");
        }

        /// <summary>
        /// 查询维修项目列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(PagedFilter filter)
        {
            var modelList = new List<PurchaseOrderModel>();
            var result = PurchaseService.Find(filter);
            foreach (var item in result.Data)
            {
                var purchaseBy = EmployeeService.GetById(item.PurchaseById);
                var supplier = SupplierService.GetById(item.SupplierId);
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
                    SupplierName = supplier == null ? string.Empty : supplier.Name,
                });
            }

            var response = new PagedResult<PurchaseOrderModel>();
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
        public ActionResult Edit(Guid id)
        {
            ViewBag.EmployeeList = EmployeeService.FindNormalList();

            var model = new PurchaseOrder();
            model.Id = id;
            return View("Edit", model);
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
                PurchaseService.SaveOrUpdate(model);
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