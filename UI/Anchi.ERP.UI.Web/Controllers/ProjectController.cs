using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.Projects;
using Anchi.ERP.Service.Projects;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 维修项目管理
    /// </summary>
    [UserAuthorize]
    public class ProjectController : BaseController
    {
        #region 构造函数和属性
        public ProjectController() : this(new ProjectService()) { }

        public ProjectController(ProjectService projectService)
        {
            this.ProjectService = projectService;
        }

        ProjectService ProjectService { get; }
        #endregion

        #region 修改项目管理
        /// <summary>
        /// 修改项目管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询维修项目列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult List(PagedFilter filter)
        {
            var result = ProjectService.Find(filter);
            return new BetterJsonResult(result, true);
        }
        #endregion

        #region 新增维修项目
        /// <summary>
        /// 新增维修项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View("Edit");
        }
        #endregion

        #region 修改维修项目
        /// <summary>
        /// 修改维修项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = ProjectService.GetById(id);
            return View(model);
        }
        #endregion

        #region 保存维修项目
        /// <summary>
        /// 保存维修项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Project model)
        {
            try
            {
                ProjectService.SaveOrUpdate(model);
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 删除维修项目
        /// <summary>
        /// 删除维修项目
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(IList<Guid> Ids)
        {
            try
            {
                ProjectService.DeleteList(Ids.ToArray());
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 选择维修项目
        /// <summary>
        /// 选择维修项目
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SelectRepairProject()
        {
            return View();
        }
        #endregion
    }
}