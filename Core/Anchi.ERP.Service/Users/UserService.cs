using Anchi.ERP.Common.Security;
using Anchi.ERP.Repository.Users;
using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Enum;
using Anchi.ERP.Domain.Users.Filter;
using System;
using System.Linq;

namespace Anchi.ERP.Service.Users
{
    /// <summary>
    /// 用户管理服务层
    /// </summary>
    public class UserService : BaseService<User>
    {
        #region 构造函数和属性
        public UserService() : this(new UserRepository()) { }

        public UserService(UserRepository userRepository) : base(userRepository)
        {
            this.UserRepository = userRepository;
        }

        UserRepository UserRepository { get; }
        #endregion

        #region 根据登录名和密码查询用户
        /// <summary>
        /// 根据登录名和密码查询用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        public User GetModel(string loginName, string passWord)
        {
            if (string.IsNullOrWhiteSpace(loginName) || string.IsNullOrWhiteSpace(passWord))
                return null;

            var filter = new FindUserFilter();
            filter.LoginName = loginName;
            filter.PassWord = MD5.GetMd5Value(passWord);
            var userList = UserRepository.Find<User>(filter);
            return userList.FirstOrDefault();
        }
        #endregion

        #region 保存用户
        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public User SaveOrUpdate(User model)
        {
            if (model == null)
                throw new Exception("提交数据错误。");

            if (string.IsNullOrWhiteSpace(model.TrueName))
                throw new Exception("请输入用户姓名。");

            if (string.IsNullOrWhiteSpace(model.LoginName))
                throw new Exception("请输入登录名。");

            var temp = GetModel(model.Id);
            if (temp == null)
            {
                if (string.IsNullOrWhiteSpace(model.Password))
                    throw new Exception("请输入密码。");

                model.Password = MD5.GetMd5Value(model.Password);
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                model.Status = EnumUserStatus.Normal;
                UserRepository.Create(model);
            }
            else
            {
                model.Password = string.IsNullOrWhiteSpace(model.Password) ? temp.Password : MD5.GetMd5Value(model.Password);
                model.Status = model.Status == 0 ? temp.Status : model.Status;
                model.CreatedOn = temp.CreatedOn;
                UserRepository.Update(model);
            }
            return model;
        }
        #endregion
    }
}
