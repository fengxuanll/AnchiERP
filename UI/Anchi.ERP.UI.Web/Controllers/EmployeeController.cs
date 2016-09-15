using Anchi.ERP.Domain.Employees;
using Anchi.ERP.Domain.Employees.Filter;
using Anchi.ERP.Service.Employees;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 员工控制器
    /// </summary>
    public class EmployeeController : Controller
    {
        #region 构造函数和属性
        /// <summary>
        /// 构造函数
        /// </summary>
        public EmployeeController() : this(new EmployeeService())
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeeController(EmployeeService employeeService)
        {
            this.EmployeeService = employeeService;
        }

        EmployeeService EmployeeService
        {
            get;
        }
        #endregion

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询员工列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult List(FindEmployeeFilter filter)
        {
            var result = EmployeeService.FindPaged(filter);
            return new BetterJsonResult(result, true);
        }

        /// <summary>
        /// 获取所有在职的员工列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ListNormal()
        {
            var result = EmployeeService.FindNormalList();
            return new BetterJsonResult(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            var model = new Employee();
            model.EntryOn = DateTime.Now.Date;
            return View("Edit", model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = EmployeeService.GetModel(id);
            return View(model);
        }

        /// <summary>
        /// 保存员工
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Employee model)
        {
            try
            {
                EmployeeService.SaveOrUpdate(model);
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }

        #region 删除员工
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(IList<Guid> Ids)
        {
            try
            {
                EmployeeService.DeleteList(Ids.ToArray());
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 启用员工账号
        /// <summary>
        /// 启用员工账号
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Enable(IList<Guid> idList)
        {
            try
            {
                EmployeeService.EnableEmployee(idList);
                return new BetterJsonResult();
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 停用员工账号
        /// <summary>
        /// 停用员工账号
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Disable(IList<Guid> idList)
        {
            try
            {
                EmployeeService.DisableEmployee(idList);
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