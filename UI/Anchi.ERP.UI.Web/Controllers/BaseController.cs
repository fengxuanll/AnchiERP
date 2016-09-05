using Anchi.ERP.Domain.Users;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 
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
    }
}