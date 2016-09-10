using System;
using System.Net;

namespace Anchi.ERP.Common.Net
{
    /// <summary>
    /// Http请求结果
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// Http请求状态
        /// </summary>
        public HttpStatusCode StatusCode
        {
            get; set;
        }

        /// <summary>
        /// 请求原始结果
        /// </summary>
        public string OriginalResult
        {
            get; set;
        }

        /// <summary>
        /// 其他返回结果
        /// </summary>
        public object OtherResult
        {
            get; set;
        }

        /// <summary>
        /// 异常信息
        /// </summary>
        public Exception Exception
        {
            get; set;
        }
    }
}
