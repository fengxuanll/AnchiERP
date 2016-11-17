using System;
using System.IO;

namespace Anchi.ERP.Common.IO
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileUtils
    {
        #region 追加文本到文件
        /// <summary>
        /// 追加文本到文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static void WriteText(string filePath, string text)
        {
            if (!Path.IsPathRooted(filePath))
                return;

            var fileDir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(fileDir))
                Directory.CreateDirectory(fileDir);

            text = text + Environment.NewLine;
            File.AppendAllText(filePath, text);
        }
        #endregion

        #region 将Base64编码过的字符串保存到文件
        /// <summary>
        /// 将Base64编码过的字符串保存到文件
        /// </summary>
        /// <param name="base64String"></param>
        /// <param name="filePath">文件的绝对路径</param>
        public static void SaveBase64File(string base64String, string filePath)
        {
            if (!Path.IsPathRooted(filePath))
                return;

            var fileBytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(filePath, fileBytes);
        }
        #endregion
    }
}
