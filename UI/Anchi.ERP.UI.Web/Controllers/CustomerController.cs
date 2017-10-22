using Anchi.ERP.Domain.Customers;
using Anchi.ERP.Domain.Customers.Filter;
using Anchi.ERP.Service.Customers;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 客户管理
    /// </summary>
    [UserAuthorize]
    public class CustomerController : BaseController
    {
        #region 构造函数和属性
        public CustomerController(CustomerService customerService)
        {
            this.CustomerService = customerService;
        }

        CustomerService CustomerService
        {
            get;
        }
        #endregion

        #region 客户管理
        /// <summary>
        /// 客户管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult List(FindCustomerFilter filter)
        {
            var result = CustomerService.FindPaged(filter);
            return new BetterJsonResult(result, true);
        }
        #endregion

        #region 新增客户
        /// <summary>
        /// 新增客户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            var model = new Customer();
            return View("Edit", model);
        }
        #endregion

        #region 修改客户
        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = CustomerService.GetModel(id);
            return View(model);
        }
        #endregion

        #region 保存客户
        /// <summary>
        /// 保存客户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Customer model)
        {
            try
            {
                CustomerService.SaveOrUpdate(model);
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 删除客户
        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(IList<Guid> Ids)
        {
            try
            {
                CustomerService.DeleteList(Ids.ToArray());
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 选择客户
        /// <summary>
        /// 选择客户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SelectCustomer()
        {
            return View();
        }
        #endregion
    }
}