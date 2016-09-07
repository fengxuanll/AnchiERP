using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Enum;
using Anchi.ERP.Service.Users;
using Anchi.ERP.UI.Web.Filter;
using Anchi.ERP.UI.Web.Models;
using System;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : BaseController
    {
        public LoginController() : this(new UserService())
        { }

        public LoginController(UserService userService)
        {
            this.UserService = userService;
        }

        UserService UserService
        {
            get;
        }

        /// <summary>
        /// 初始化默认用户
        /// </summary>
        /// <returns></returns>
        public ActionResult Init()
        {
            var Id = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var model = UserService.GetById(Id);
            if (model != null)
                return new BetterJsonResult("已存在默认用户。", true);

            model = new User
            {
                Id = Id,
                LoginName = "admin",
                TrueName = "admin",
                Password = "admin",
                Status = EnumUserStatus.Normal,
                CreatedOn = DateTime.Now,
                Remark = "默认用户",
            };
            UserService.SaveOrUpdate(model);

            return new BetterJsonResult("初始化成功。", true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            if (base.CurrentUser != null)
                Response.Redirect("/");

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.UserName))
                return new BetterJsonResult("请属于用户名。");

            if (string.IsNullOrWhiteSpace(model.PassWord))
                return new BetterJsonResult("请输入密码。");

            var user = UserService.GetModel(model.UserName.Trim(), model.PassWord.Trim());
            if (user == null)
                return new BetterJsonResult("用户名或密码无效。");

            if (user.Status != EnumUserStatus.Normal)
                return new BetterJsonResult("该账号已被禁用，请联系管理员。");

            base.CurrentUser = user;
            return new BetterJsonResult(null, true);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            base.CurrentUser = null;
            return Redirect("/Login");
        }
    }
}