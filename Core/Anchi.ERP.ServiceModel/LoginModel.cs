namespace Anchi.ERP.ServiceModel
{
    /// <summary>
    /// 用户登录实体
    /// </summary>
    public class LoginModel
    {
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
    }
}
