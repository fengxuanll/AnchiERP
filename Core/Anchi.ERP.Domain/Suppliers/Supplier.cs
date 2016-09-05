using ServiceStack.DataAnnotations;

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
        [Required]
        [Index(unique: true)]
        [StringLength(50)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 联系人
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Contact
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
