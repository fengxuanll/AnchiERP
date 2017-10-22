using System.Collections.Specialized;
using System.Configuration;

namespace Anchi.ERP.Common.Configuration
{
    /// <summary>
    /// dll配置读取类
    /// </summary>
    public class DllConfiguration
    {
        public DllConfiguration(string dllConfigFileName)
        {
            string dllConfigFilePath = null;
            ConfigHelper.SearchConfigFilePath(dllConfigFileName, true, out dllConfigFilePath);
            configSystem = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap
            {
                ExeConfigFilename = dllConfigFilePath
            }, ConfigurationUserLevel.None);
        }
        private System.Configuration.Configuration configSystem;

        NameValueCollection appsettings = null;
        public NameValueCollection AppSettings
        {
            get
            {
                if (this.appsettings == null)
                {
                    this.appsettings = new NameValueCollection();

                    var section = configSystem.GetSection("appSettings") as AppSettingsSection;
                    if (section == null)
                        throw new ConfigurationErrorsException("Config appsettings declaration invalid");

                    if (section.Settings != null && section.Settings.AllKeys != null)
                    {
                        foreach (string key in section.Settings.AllKeys)
                        {
                            appsettings.Add(key, section.Settings[key].Value);
                        }
                    }
                }
                return appsettings;
            }
        }

        public ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                var connectionStringsSection = configSystem.GetSection("connectionStrings") as ConnectionStringsSection;
                if (connectionStringsSection == null)
                    throw new ConfigurationErrorsException("Config connectionstrings declaration invalid");

                return connectionStringsSection.ConnectionStrings;
            }
        }

        public ConfigurationSection GetSection(string sectionName)
        {
            if (string.IsNullOrEmpty(sectionName))
                return null;

            return configSystem.GetSection(sectionName);
        }
    }
}
