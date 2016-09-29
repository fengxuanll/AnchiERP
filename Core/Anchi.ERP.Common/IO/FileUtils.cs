using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Anchi.ERP.Common.IO
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileUtils
    {
        /// <summary>
        /// 写文本到文件
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
    }
}
