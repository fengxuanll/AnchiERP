using Anchi.ERP.Common.Logging;
using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Enum;
using Anchi.ERP.Service.Users;
using Anchi.ERP.ServiceModel;
using Anchi.ERP.UI.Web.Filter;
using System;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Controllers
{
    /// <summary>
    /// 登录控制器
    /// </summary>
    public class LoginController : BaseController
    {
        #region 构造函数和属性
        public LoginController(UserService userService)
        {
            this.UserService = userService;
        }

        UserService UserService { get; }
        #endregion

        #region 初始化默认用户
        /// <summary>
        /// 初始化默认用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Init()
        {
            var Id = Guid.Parse("00000000-0000-0000-0000-000000000001");
            var model = UserService.Get(Id);
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

#if DEBUG
            //InitTestData();
#endif
            return new BetterJsonResult("初始化成功。", true);
        }
        #endregion

        #region 造点测试数据
        /// <summary>
        /// 造点测试数据
        /// </summary>
        //public void InitTestData()
        //{
        //    var employeeService = new Service.Employees.EmployeeService();
        //    var productService = new Service.Products.ProductService();
        //    var projectService = new Service.Projects.ProjectService();
        //    var customerService = new Service.Customers.CustomerService();
        //    var supplierService = new Service.Suppliers.SupplierService();
        //    var productStockRecordService = new Service.Products.ProductStockRecordService();
        //    var purchaseService = new Service.Purchases.PurchaseService();
        //    var repairOrderService = new Service.Repairs.RepairOrderService();
        //    var saleOrderService = new Service.SaleOrders.SaleOrderService();

        //    for (int i = 0; i < 100; i++)
        //    {
        //        employeeService.SaveOrUpdate(new Domain.Employees.Employee
        //        {
        //            Name = "员工" + (i + 1),
        //            Code = "员工" + (i + 1),
        //            EntryOn = DateTime.Now,
        //            Status = Domain.Employees.Enum.EnumEmployeeStatus.Normal,
        //        });

        //        productService.SaveOrUpdate(new Domain.Products.Product
        //        {
        //            Code = "配件" + (i + 1),
        //            Name = "配件" + (i + 1),
        //            Stock = 1000,
        //            SafeStock = 100,
        //            CostPrice = 80 + i,
        //            SalePrice = 100 + i,
        //        });

        //        projectService.SaveOrUpdate(new Domain.Projects.Project
        //        {
        //            Code = "维修项目" + (i + 1),
        //            Name = "维修项目" + (i + 1),
        //            UnitPrice = 100 + i,
        //        });

        //        customerService.SaveOrUpdate(new Domain.Customers.Customer
        //        {
        //            Name = "客户" + (i + 1),
        //            CarNumber = "车牌号" + (i + 1),
        //        });

        //        supplierService.SaveOrUpdate(new Domain.Suppliers.Supplier
        //        {
        //            CompanyName = "供应商" + (i + 1),
        //            Contact = "供应商" + (i + 1),
        //        });
        //    }
        //}
        #endregion

        #region 用户登录
        /// <summary>
        /// 用户登录
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
        /// 用户登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.LoginName))
                return new BetterJsonResult("请输入登录名。");

            if (string.IsNullOrWhiteSpace(model.PassWord))
                return new BetterJsonResult("请输入密码。");

            var user = UserService.GetModel(model.LoginName.Trim(), model.PassWord.Trim());
            if (user == null)
                return new BetterJsonResult("用户名或密码无效。");

            if (user.Status != EnumUserStatus.Normal)
                return new BetterJsonResult("该账号已被禁用，请联系管理员。");

            base.CurrentUser = user;

            LogWriter.InfoFormat("{0} {1} 登录", user.TrueName, user.LoginName);

            return new BetterJsonResult(null, true);
        }
        #endregion

        #region 退出系统
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Logout()
        {
            base.CurrentUser = null;
            return Redirect("/Login");
        }
        #endregion
    }
}