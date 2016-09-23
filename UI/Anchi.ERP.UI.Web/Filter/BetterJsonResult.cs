using Anchi.ERP.Common;
using System.Web.Mvc;

namespace Anchi.ERP.UI.Web.Filter
{
    /// <summary>
    /// Ajax输出结果
    /// </summary>
    public class BetterJsonResult : ActionResult
    {
        /// <summary>
        /// 如果是输出成功的结果，可以用这个构造函数
        /// </summary>
        public BetterJsonResult() : this(null, true) { }

        public BetterJsonResult(object data, bool success = false)
        {
            this.Data = data;
            this.Success = success;
        }

        object Data
        {
            get;
        }

        bool Success
        {
            get;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";

            var response = JsonUtils.Serialize(new
            {
                Success = this.Success,
                Message = this.Data,
            });
            context.HttpContext.Response.Output.Write(response);
        }
    }
}