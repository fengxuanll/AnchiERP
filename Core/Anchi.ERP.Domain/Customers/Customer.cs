using ServiceStack.DataAnnotations;

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
        [Required]
        [StringLength(50)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 车牌号
        /// </summary>
        [Required]
        [Index(unique: true)]
        [StringLength(20)]
        public string CarNumber
        {
            get; set;
        }

        /// <summary>
        /// 电话
        /// </summary>
        [StringLength(50)]
        public string Tel
        {
            get; set;
        }

        /// <summary>
        /// 地址
        /// </summary>
        [StringLength(100)]
        public string Address
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(1000)]
        public string Remark
        {
            get; set;
        }
    }
}
