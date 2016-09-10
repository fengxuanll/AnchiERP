using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Anchi.ERP.Common.Net
{
    /// <summary>
    /// Http请求公用类
    /// </summary>
    public static class HttpUtils
    {
        static Encoding encoding = Encoding.UTF8;

        #region 发送请求
        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="request"></param>
        public static HttpResponse SendRequest(HttpRequest request)
        {
            var response = new HttpResponse();

            var webRequest = (HttpWebRequest)WebRequest.Create(request.Url);
            if (request.Url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                webRequest.ProtocolVersion = HttpVersion.Version10;
            }
            webRequest.Method = request.Method.ToString().ToUpper();
            // 设置请求头部信息
            foreach (var header in request.Headers)
            {
                switch (header.Key)
                {
                    case "Content-Type":
                        webRequest.ContentType = header.Value;
                        break;
                    default:
                        webRequest.Headers.Add(header.Key, header.Value);
                        break;
                }
            }
            SetHeaderAuthorization(webRequest, request);
            // 设置超时时间
            if (request.Timeout > 0)
            {
                webRequest.Timeout = request.Timeout * 1000;
            }

            HttpWebResponse httpResponse = null;
            try
            {
                // 设置请求主体
                SetRequestBody(webRequest, request);

                httpResponse = (HttpWebResponse)webRequest.GetResponse();
                using (var stream = httpResponse.GetResponseStream())
                {
                    switch (httpResponse.ContentType)
                    {
                        case "application/pdf":
                            var outstream = new MemoryStream();
                            CopyStream(stream, outstream);
                            response.OtherResult = outstream.ToArray();
                            break;
                        default:
                            using (var reader = new StreamReader(stream, encoding))
                            {
                                response.OriginalResult = reader.ReadToEnd();
                            }
                            break;
                    }
                }
                httpResponse.Close();
            }
            catch (WebException ex)
            {
                response.Exception = ex;
                if (ex.Response != null)
                {
                    using (var stream = ex.Response.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (var reader = new StreamReader(stream, encoding))
                            {
                                response.OriginalResult = reader.ReadToEnd();
                                if (!string.IsNullOrWhiteSpace(response.OriginalResult))
                                    response.Exception = null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }
            if (httpResponse != null)
            {
                response.StatusCode = httpResponse.StatusCode;
            }

            return response;
        }
        #endregion

        #region 设置请求授权
        /// <summary>
        /// 设置请求授权
        /// </summary>
        /// <param name="webRequest"></param>
        /// <param name="request"></param>
        private static void SetHeaderAuthorization(WebRequest webRequest, HttpRequest request)
        {
            if (request.AuthType == EnumAuthorizationType.BasicAuth)
            {
                var auth = string.Format("{0}:{1}", request.Username, request.Password);
                webRequest.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(encoding.GetBytes(auth));
            }
        }
        #endregion

        #region 设置请求主体
        /// <summary>
        /// 设置请求主体
        /// </summary>
        /// <param name="webRequest"></param>
        /// <param name="request"></param>
        private static void SetRequestBody(WebRequest webRequest, HttpRequest request)
        {
            if (request.Method == EnumHttpVerbs.Get || string.IsNullOrWhiteSpace(request.Body))
                return;

            var data = encoding.GetBytes(request.Body);
            using (var stream = webRequest.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        #endregion

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

        #region 复制流
        /// <summary>
        /// 复制流
        /// </summary>
        /// <param name="instream"></param>
        /// <param name="outstream"></param>
        private static void CopyStream(Stream instream, Stream outstream)
        {
            const int bufferLen = 4096;
            byte[] buffer = new byte[bufferLen];
            int count = 0;
            while ((count = instream.Read(buffer, 0, bufferLen)) > 0)
            {
                outstream.Write(buffer, 0, count);
            }
        }
        #endregion
    }
}
