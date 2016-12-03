using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Anchi.ERP.Common.IO
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public class FileHelper
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

        #region 尝试获取照片拍摄时间
        /// <summary>
        /// 尝试获取照片拍摄时间
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="shootTime"></param>
        /// <returns></returns>
        private static bool TryGetShootTime(string filePath, out DateTime shootTime)
        {
            shootTime = DateTime.MinValue;

            if (!File.Exists(filePath))
                return false;

            try
            {
                using (var image = Image.FromFile(filePath))
                {
                    if (image.PropertyItems == null || !image.PropertyItems.Any())
                        return false;

                    var propertyItem = image.PropertyItems.FirstOrDefault(item => item.Id == 0x0132);
                    if (propertyItem == null || propertyItem.Value == null || !propertyItem.Value.Any())
                        return false;

                    var shootTimeString = Encoding.UTF8.GetString(propertyItem.Value);
                    var timePartList = shootTimeString.Split(new string[] { " ", ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    if (timePartList.Count > 5)
                        return false;

                    shootTime = new DateTime(Convert.ToInt32(timePartList[0]), Convert.ToInt32(timePartList[1]), Convert.ToInt32(timePartList[2]),
                                            Convert.ToInt32(timePartList[3]), Convert.ToInt32(timePartList[4]), Convert.ToInt32(timePartList[5]));

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
