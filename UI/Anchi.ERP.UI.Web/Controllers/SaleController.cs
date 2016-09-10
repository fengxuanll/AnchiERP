using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.SaleOrders;
using Anchi.ERP.Service.SaleOrders;
using Anchi.ERP.UI.Web.Filter;
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
        public SaleController() : this(new SaleOrderService()) { }

        public SaleController(SaleOrderService saleOrderService)
        {
            this.SaleOrderService = saleOrderService;
        }

        SaleOrderService SaleOrderService
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
        public ActionResult List(PagedFilter filter)
        {
            var result = SaleOrderService.Find(filter);
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
            return View("Edit");
        }

        /// <summary>
        /// 新增销售单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(SaleOrder model)
        {
            return new BetterJsonResult(null, true);
        }
        #endregion
    }
}