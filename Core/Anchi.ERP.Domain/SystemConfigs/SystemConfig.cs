namespace Anchi.ERP.Domain.SystemConfigs
{
    /// <summary>
    /// 系统配置
    /// </summary>
    public class SystemConfig : BaseDomain
    {
        /// <summary>
        /// 标识
        /// </summary>
        public string Key
        {
            get; set;
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Value
        {
            get; set;
        }
    }
}
