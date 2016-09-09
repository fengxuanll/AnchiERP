using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.RepairOrder;
using Anchi.ERP.Service.Employees;
using Anchi.ERP.Service.Repairs;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    [UserAuthorize]
    public class RepairController : BaseController
    {
        #region 构造函数和属性
        public RepairController() : this(new RepairOrderService(), new EmployeeService())
        {
        }

        public RepairController(RepairOrderService repairOrderService, EmployeeService employeeService)
        {
            this.RepairOrderService = repairOrderService;
            this.EmployeeService = employeeService;
        }

        RepairOrderService RepairOrderService
        {
            get;
        }

        EmployeeService EmployeeService
        {
            get;
        }
        #endregion

        #region 维修单管理
        /// <summary>
        /// 维修单管理
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            return View("Index");
        }

        /// <summary>
        /// 维修单管理列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(PagedFilter filter)
        {
            var result = RepairOrderService.Find(filter);
            return new BetterJsonResult(result, true);
        }
        #endregion

        #region 新增维修单
        /// <summary>
        /// 新增维修单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.EmployeeList = EmployeeService.GetNormalList();
            return View("Edit");
        }

        /// <summary>
        /// 新增维修单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(RepairOrder model)
        {
            try
            {
                RepairOrderService.Create(model);
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 取消维修单
        /// <summary>
        /// 取消维修单
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Cancel(IList<Guid> idList)
        {
            return new BetterJsonResult(null, true);
        }
        #endregion

        #region 设置已完工
        /// <summary>
        /// 设置已完工
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Complete(IList<Guid> idList)
        {
            return new BetterJsonResult();
        }
        #endregion

        #region 设置已结算
        /// <summary>
        /// 设置已结算
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Settlement(IList<Guid> idList)
        {
            return new BetterJsonResult();
        }
        #endregion
    }
}