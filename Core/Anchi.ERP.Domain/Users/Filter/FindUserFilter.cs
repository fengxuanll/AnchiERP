using Anchi.ERP.Common.Filter;
using Anchi.ERP.Domain.Users.Enum;
using System.Text;

namespace Anchi.ERP.Domain.Users.Filter
{
    /// <summary>
    /// 查找用户信息筛选类
    /// </summary>
    public class FindUserFilter : PagedQueryFilter
    {
        /// <summary>
        /// 要执行的SQL
        /// </summary>
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("SELECT * FROM [User] WHERE 1 = 1");

                if (!string.IsNullOrWhiteSpace(this.Tel))
                {
                    sb.AppendLine(" AND [Tel] = @Tel");
                    this.ParamDict.Add("@Tel", this.Tel);
                }

                if (!string.IsNullOrWhiteSpace(this.Tel))
                {
                    sb.AppendLine(" AND [TrueName] = @TrueName");
                    this.ParamDict.Add("@TrueName", this.TrueName);
                }

                return sb.ToString();
            }
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
        /// 身份证号
        /// </summary>
        public string IDCard
        {
            get; set;
        }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName
        {
            get; set;
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get; set;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public EnumUserStatus? Status
        {
            get; set;
        }
    }
}
