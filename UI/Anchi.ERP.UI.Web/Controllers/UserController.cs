using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Enum;
using Anchi.ERP.Service.Users;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    [UserAuthorize]
    public class UserController : BaseController
    {
        public UserController() : this(new UserService())
        { }

        public UserController(UserService userService)
        {
            this.UserService = userService;
        }

        UserService UserService
        { get; }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult List(PagedFilter filter)
        {
            var result = UserService.Find(filter);
            return new BetterJsonResult(result, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            var model = new User();
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
            var model = UserService.GetById(id);
            return View(model);
        }

        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(User model)
        {
            try
            {
                UserService.SaveOrUpdate(model);
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(IList<Guid> Ids)
        {
            try
            {
                UserService.DeleteList(Ids.ToArray());
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }

        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="IdList"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public ActionResult UpdateStatus(IList<Guid> IdList, EnumUserStatus Status)
        {
            foreach (var Id in IdList)
            {
                var model = UserService.GetById(Id);
                if (model == null)
                    continue;

                model.Status = Status;
                UserService.SaveOrUpdate(model);
            }
            return new BetterJsonResult(null, true);
        }
    }
}