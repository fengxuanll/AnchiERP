using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.Suppliers;
using Anchi.ERP.Service.Suppliers;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 供应商管理
    /// </summary>
    [UserAuthorize]
    public class SupplierController : BaseController
    {
        #region 构造函数和属性
        public SupplierController() : this(new SupplierService()) { }

        public SupplierController(SupplierService supplierService)
        {
            this.SupplierService = supplierService;
        }

        SupplierService SupplierService { get; }
        #endregion

        #region 供应商管理
        /// <summary>
        /// 供应商管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询供应商列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult List(PagedFilter filter)
        {
            var result = SupplierService.Find(filter);
            return new BetterJsonResult(result, true);
        }
        #endregion

        #region 新增供应商
        /// <summary>
        /// 新增供应商
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            var model = new Supplier();
            return View("Edit", model);
        }
        #endregion

        #region 修改供应商
        /// <summary>
        /// 修改供应商
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = SupplierService.GetById(id);
            return View(model);
        }
        #endregion

        #region 保存供应商
        /// <summary>
        /// 保存供应商
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Supplier model)
        {
            try
            {
                SupplierService.SaveOrUpdate(model);
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 删除供应商
        /// <summary>
        /// 删除供应商
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(IList<Guid> Ids)
        {
            try
            {
                SupplierService.DeleteList(Ids.ToArray());
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 选择供应商
        /// <summary>
        /// 选择供应商
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SelectSupplier()
        {
            return View();
        }
        #endregion
    }
}