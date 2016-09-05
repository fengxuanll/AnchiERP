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
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}