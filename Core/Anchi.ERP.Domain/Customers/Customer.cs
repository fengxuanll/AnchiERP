namespace Anchi.ERP.Domain.Customers
{
    /// <summary>
    /// 客户信息
    /// </summary>
    public class Customer : BaseDomain
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarNumber
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
