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
                var sb = new StringBuilder("SELECT * FROM [User] WHERE 1 = 1");
                if (!string.IsNullOrWhiteSpace(this.TrueName))
                {
                    sb.AppendLine(" AND [TrueName] = @TrueName");
                    this.ParamDict["@TrueName"] = this.TrueName;
                }
                if (!string.IsNullOrWhiteSpace(this.LoginName))
                {
                    sb.AppendLine(" AND [LoginName] = @LoginName");
                    this.ParamDict["@LoginName"] = this.LoginName;
                }
                if (!string.IsNullOrWhiteSpace(this.PassWord))
                {
                    sb.AppendLine(" AND [PassWord] = @PassWord");
                    this.ParamDict["@PassWord"] = this.PassWord;
                }
                if (this.Status.HasValue)
                {
                    sb.AppendLine(" AND [Status] = @Status");
                    this.ParamDict["@Status"] = (byte)this.Status.Value;
                }

                return sb.ToString();
            }
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
        /// 密码
        /// </summary>
        public string PassWord
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
