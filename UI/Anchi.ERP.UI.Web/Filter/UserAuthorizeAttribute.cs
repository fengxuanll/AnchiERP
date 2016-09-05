using Anchi.ERP.Domain.Users;
using System.Web.Mvc;
using System.Web;

namespace Anchi.ERP.UI.Web.Filter
{
    public class UserAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUser = (User)httpContext.Session["CurrentUser"];
            return currentUser != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Login");
        }
    }
}