using Anchi.ERP.Domain.Products;
using Anchi.ERP.Domain.Products.Filter;
using Anchi.ERP.Service.Products;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 配件管理
    /// </summary>
    [UserAuthorize]
    public class ProductController : BaseController
    {
        #region 构造函数和属性
        public ProductController() : this(new ProductService(), new ProductStockRecordService()) { }

        public ProductController(ProductService productService, ProductStockRecordService productStockRecordService)
        {
            this.ProductService = productService;
            this.ProductStockRecordService = productStockRecordService;
        }

        ProductService ProductService
        {
            get;
        }

        ProductStockRecordService ProductStockRecordService
        {
            get;
        }
        #endregion

        #region 配件管理
        /// <summary>
        /// 配件管理
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询配件列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult List(FindProductFilter filter)
        {
            var result = ProductService.FindPaged(filter);
            return new BetterJsonResult(result, true);
        }
        #endregion

        #region 新增配件
        /// <summary>
        /// 新增配件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            var model = new Product();
            return View("Edit", model);
        }
        #endregion

        #region 修改配件
        /// <summary>
        /// 修改配件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = ProductService.GetModel(id);
            return View(model);
        }
        #endregion

        #region 保存配件
        /// <summary>
        /// 保存配件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Product model)
        {
            try
            {
                ProductService.SaveOrUpdate(model);
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 删除配件
        /// <summary>
        /// 删除配件
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(IList<Guid> Ids)
        {
            try
            {
                ProductService.DeleteList(Ids.ToArray());
                return new BetterJsonResult(null, true);
            }
            catch (Exception ex)
            {
                return new BetterJsonResult(ex.Message);
            }
        }
        #endregion

        #region 选择配件
        /// <summary>
        /// 选择配件
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult SelectRepairProduct()
        {
            return View();
        }
        #endregion

        #region 配件出入库记录
        /// <summary>
        /// 配件出入库记录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Record()
        {
            return View();
        }

        /// <summary>
        /// 配件出入库记录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RecordList(FindProductStockRecordFilter filter)
        {
            var result = ProductStockRecordService.FindList(filter);
            return new BetterJsonResult(result, true);
        }
        #endregion
    }
}