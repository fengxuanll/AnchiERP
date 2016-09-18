using Anchi.ERP.Common.Logging;
using Anchi.ERP.Domain.Users;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 基础控制器，所有的控制器都应该继承此类
    /// </summary>
    public class BaseController : Controller
    {
        #region 当前登录用户
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public User CurrentUser
        {
            get
            {
                return (User)HttpContext.Session["CurrentUser"];
            }
            set
            {
                Session["CurrentUser"] = value;
            }
        }
        #endregion

        #region 记录异常日志
        /// <summary>
        /// 记录异常日志
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnException(ExceptionContext filterContext)
        {
            LogWriter.ErrorFormat("Controller Exception：{0}", filterContext.Exception);

            base.OnException(filterContext);
        }
        #endregion

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!Request.IsAjaxRequest())
            {
                ViewBag.CurrentUser = CurrentUser;
            }
            base.OnActionExecuted(filterContext);
        }
    }
}