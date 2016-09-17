using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.SaleOrders;
using Anchi.ERP.Domain.SaleOrders.Filter;
using Anchi.ERP.Service.Employees;
using Anchi.ERP.Service.SaleOrders;
using Anchi.ERP.ServiceModel.Sales;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 销售管理
    /// </summary>
    [UserAuthorize]
    public class SaleController : BaseController
    {
        #region 构造函数和属性
        public SaleController() : this(new SaleOrderService(), new EmployeeService()) { }

        public SaleController(SaleOrderService saleOrderService, EmployeeService employeeService)
        {
            this.SaleOrderService = saleOrderService;
            this.EmployeeService = employeeService;
        }

        SaleOrderService SaleOrderService
        {
            get;
        }
        EmployeeService EmployeeService
        {
            get;
        }
        #endregion

        #region 销售单管理
        /// <summary>
        /// 销售单管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            return View("Index");
        }

        /// <summary>
        /// 销售单管理列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(FindSaleOrderFilter filter)
        {
            var result = this.SaleOrderService.FindList(filter);
            return new BetterJsonResult(result, true);
        }
        #endregion

        #region 新增销售单
        /// <summary>
        /// 新增销售单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.EmployeeList = EmployeeService.FindNormalList();

            var model = new SaleOrder();
            model.SaleOn = DateTime.Now;
            return View("Edit", model);
        }
        #endregion

        #region 修改销售单
        /// <summary>
        /// 修改销售单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ViewBag.EmployeeList = EmployeeService.FindNormalList();

            var model = SaleOrderService.Get(id);
            return View("Edit", model);
        }

        /// <summary>
        /// 获取销售单详细信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetEditModel(Guid Id)
        {
            ViewBag.EmployeeList = EmployeeService.FindNormalList();

            var model = SaleOrderService.GetModel(Id);
            return new BetterJsonResult(model, true);
        }
        #endregion

        #region 保存销售单
        /// <summary>
        /// 保存销售单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(SaleOrder model)
        {
            try
            {
                if (model.Id == Guid.Empty)
                    model.CreatedById = base.CurrentUser.Id;

                SaleOrderService.SaveOrUpdate(model);
                return new BetterJsonResult();
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 销售单出库
        /// <summary>
        /// 销售单出库
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public ActionResult Outbound(IList<Guid> idList)
        {
            try
            {
                SaleOrderService.Outbound(idList);
                return new BetterJsonResult();
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 结算销售单
        /// <summary>
        /// 结算销售单
        /// </summary>
        /// <param name="id">Identifier.</param>
        [HttpGet]
        public ActionResult Settlement(Guid id)
        {
            return View();
        }

        /// <summary>
        /// 结算销售单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
		[HttpPost]
        public ActionResult SettlementOrder(SaleSettlementModel model)
        {
            try
            {
                SaleOrderService.Settlement(model);
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