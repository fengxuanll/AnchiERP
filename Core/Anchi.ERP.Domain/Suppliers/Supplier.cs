namespace Anchi.ERP.Domain.Suppliers
{
    /// <summary>
    /// 供应商
    /// </summary>
    public class Supplier : BaseDomain
    {
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact
        {
            get; set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        public string Tel
        {
            get; set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
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
