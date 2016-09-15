namespace Anchi.ERP.Domain.Projects
{
    /// <summary>
    /// 维修项目
    /// </summary>
    public class Project : BaseDomain
    {
        /// <summary>
        /// 项目编码
        /// </summary>
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal UnitPrice
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }
    }
}
