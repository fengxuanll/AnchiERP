using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    [UserAuthorize]
    public class PurchaseController : BaseController
    {
        public PurchaseController()
        {
        }

        /// <summary>
        /// 添加采购单
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View("Edit");
        }

        /// <summary>
        /// 采购单管理
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }
    }
}