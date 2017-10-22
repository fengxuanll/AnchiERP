using System;
using System.IO;
using System.Reflection;

namespace Anchi.ERP.Common.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    internal class ConfigHelper
    {
        /// <summary>
        /// 尝试搜索配置文件，如果存在则返回true，并输出完整物理文件路径。
        /// 文件名为<paramref name="configFileName"/>，扩展名为.config。
        /// 先从当前应用程序域的基目录搜索（Web应用程序为应用程序根目录），如果不存在则从基目录的 config 文件夹搜索，如果不存在则返回false。
        /// 如果<paramref name="configFileName"/>包含绝对路径，则直接返回。
        /// </summary>
        /// <param name="configFileName"></param>
        /// <param name="throwsIfNotFound"></param>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public static bool SearchConfigFilePath(string configFileName, bool throwsIfNotFound, out string configFilePath)
        {
            configFilePath = null;
            if (Path.IsPathRooted(configFileName))
            {
                // 绝对路径
                if (File.Exists(configFileName))
                {
                    configFilePath = configFileName;
                    return true;
                }
                else
                {
                    return DealSearchConfigFilePathResult(throwsIfNotFound, false, configFileName);
                }
            }
            // 先从根目录搜索
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            if (FindFile(baseDir, configFileName, ref configFilePath))
                return true;
            baseDir = AppDomain.CurrentDomain.RelativeSearchPath;
            if (string.IsNullOrEmpty(baseDir))
            {
                return DealSearchConfigFilePathResult(throwsIfNotFound, false, configFilePath);
            }
            if (FindFile(baseDir, configFileName, ref configFilePath))
                return true;
            return DealSearchConfigFilePathResult(throwsIfNotFound, false, configFilePath);
        }

        private static bool DealSearchConfigFilePathResult(bool throwsIfNotFound, bool result, string configFileName)
        {
            if (throwsIfNotFound && !result)
            {
                throw new FileNotFoundException("Not found config file at the absolute path: " + configFileName);
            }
            else
            {
                return result;
            }
        }

        private static bool FindFile(string baseDir, string configFileName, ref string configFilePath)
        {
            string tempConfigFilePath = Path.Combine(baseDir, configFileName);
            if (File.Exists(tempConfigFilePath))
            {
                configFilePath = tempConfigFilePath;
                return true;
            }

            // 根目录不存在，则尝试搜索配置目录
            tempConfigFilePath = Path.Combine(baseDir, AppSettingReader.ConfigDirectory, configFileName);
            if (File.Exists(tempConfigFilePath))
            {
                configFilePath = tempConfigFilePath;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 尝试搜索配置文件，如果存在则返回true，并输出完整物理文件路径。
        /// 文件名为指定类型<paramref name="type"/>所在的程序集的清单模块名称，扩展名为.config。
        /// 先从当前应用程序域的基目录搜索（Web应用程序为应用程序根目录），如果不存在则从基目录的 config 文件夹搜索，如果不存在则返回false。
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="throwsIfNotFound"></param>
        /// <param name="configFilePath"></param>
        /// <returns></returns>
        public static bool SearchConfigFilePath(Assembly assembly, bool throwsIfNotFound, out string configFilePath)
        {
            string configFileName = assembly.ManifestModule.Name + ".config";
            return SearchConfigFilePath(configFileName, throwsIfNotFound, out configFilePath);
        }
    }
}
