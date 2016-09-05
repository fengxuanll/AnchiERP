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
    [UserAuthorize]
    public class ProjectController : BaseController
    {
        public ProjectController() : this(new ProjectService())
        { }

        public ProjectController(ProjectService projectService)
        {
            this.ProjectService = projectService;
        }

        ProjectService ProjectService
        { get; }

        // GET: Project
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            return View("Edit");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = ProjectService.GetById(id);
            return View(model);
        }

        /// <summary>
        /// 
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
    }
}