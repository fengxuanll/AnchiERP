using System;
using System.Security.Cryptography;
using System.Text;

namespace Anchi.ERP.Common.Security
{
    /// <summary>
    /// MD5加密
    /// </summary>
    public class MD5
    {
        #region GetMd5Value
        /// <summary>
        /// GetMd5Value
        /// </summary>
        /// <param name="input"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetMd5Value(string input, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            byte[] result = encoding.GetBytes(input);
            var md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }
        #endregion
    }
}
