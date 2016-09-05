using Anchi.ERP.Domain.Users;
using ServiceStack.OrmLite;

namespace Anchi.ERP.Data.Users
{
    /// <summary>
    /// 用户仓储类
    /// </summary>
    public class UserRepository : BaseRepository<User>
    {
        /// <summary>
        /// 根据登录名和密码获取用户信息
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public User GetModel(string loginName, string passWord)
        {
            using (var db = DbFactory.Open())
            {
                return db.Single<User>(item => item.LoginName == loginName && item.Password == passWord);
            }
        }
    }
}
