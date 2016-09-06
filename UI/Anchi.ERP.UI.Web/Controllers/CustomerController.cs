using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.Customers;
using Anchi.ERP.Service.Customers;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    [UserAuthorize]
    public class CustomerController : BaseController
    {
        public CustomerController() : this(new CustomerService())
        {
        }

        public CustomerController(CustomerService customerService)
        {
            this.CustomerService = customerService;
        }

        CustomerService CustomerService
        {
            get;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询客户列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult List(PagedFilter filter)
        {
            var result = CustomerService.Find(filter);
            return new BetterJsonResult(result, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            var model = new Customer();
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
            var model = CustomerService.GetById(id);
            return View(model);
        }

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
    }
}