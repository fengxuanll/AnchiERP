using System.Collections.Generic;

namespace Anchi.ERP.Common.Net
{
    /// <summary>
    /// Http请求实体
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// 请求地址
        /// </summary>
        public string Url
        {
            get; set;
        }

        /// <summary>
        /// 请求类型
        /// </summary>
        public EnumHttpVerbs Method
        {
            get; set;
        }

        /// <summary>
        /// 授权类型
        /// </summary>
        public EnumAuthorizationType AuthType
        {
            get; set;
        }

        /// <summary>
        /// 授权用户名
        ///     AuthType为Basic Auth时有效
        /// </summary>
        public string Username
        {
            get; set;
        }

        /// <summary>
        /// 授权用户密码
        ///     AuthType为Basic Auth时有效
        /// </summary>
        public string Password
        {
            get; set;
        }

        private IDictionary<string, string> headers;
        /// <summary>
        /// 请求头部信息
        /// </summary>
        public IDictionary<string, string> Headers
        {
            get
            {
                if (headers == null)
                    headers = new Dictionary<string, string>();

                return headers;
            }
            set
            {
                headers = value;
            }
        }

        /// <summary>
        /// 超时时间（秒）
        /// </summary>
        public int Timeout
        {
            get; set;
        }

        /// <summary>
        /// 请求内容
        ///     Get请求无效
        /// </summary>
        public string Body
        {
            get; set;
        }
    }
}
