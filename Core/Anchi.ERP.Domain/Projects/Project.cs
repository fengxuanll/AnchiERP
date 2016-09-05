using ServiceStack.DataAnnotations;

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
        [Required]
        [Index(unique: true)]
        [StringLength(50)]
        public string Code
        {
            get; set;
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        [Index(unique: true)]
        [StringLength(50)]
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        [Required]
        public decimal UnitPrice
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
