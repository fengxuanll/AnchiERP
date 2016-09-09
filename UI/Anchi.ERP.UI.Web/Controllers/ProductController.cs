using Anchi.ERP.Domain.Common;
using Anchi.ERP.Domain.Products;
using Anchi.ERP.Service.Products;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 配件控制器
    /// </summary>
    [UserAuthorize]
    public class ProductController : BaseController
    {
        #region 构造函数和属性
        public ProductController() : this(new ProductService())
        {
        }

        public ProductController(ProductService productService)
        {
            this.ProductService = productService;
        }

        ProductService ProductService
        {
            get;
        }
        #endregion

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 查询配件列表
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ActionResult List(PagedFilter filter)
        {
            var result = ProductService.Find(filter);
            return new BetterJsonResult(result, true);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Add()
        {
            var model = new Product();
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
            var model = ProductService.GetById(id);
            return View(model);
        }

        /// <summary>
        /// 
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

        /// <summary>
        /// 删除维修项目
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 选择配件
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectRepairProduct()
        {
            return View();
        }
    }
}