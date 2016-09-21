using Anchi.ERP.Domain.Finances.Filter;
using Anchi.ERP.Service.Finances;
using Anchi.ERP.UI.Web.Filter;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 财务单控制器
    /// </summary>
    public class FinanceController : Controller
    {
        #region 构造函数和属性
        public FinanceController() : this(new FinanceOrderService()) { }

        public FinanceController(FinanceOrderService financeOrderService)
        {
            this.FinanceOrderService = financeOrderService;
        }

        FinanceOrderService FinanceOrderService { get; }
        #endregion

        #region 财务单列表
        /// <summary>
        /// 财务单列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 财务单列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(FindFinanceOrderFilter filter)
        {
            var result = FinanceOrderService.FindList(filter);
            return new BetterJsonResult(result, true);
        }
        #endregion
    }
}