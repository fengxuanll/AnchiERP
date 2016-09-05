using Anchi.ERP.Data.Users;
using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Enum;
using System;

namespace Anchi.ERP.Service.Users
{
    /// <summary>
    /// 用户服务层操作
    /// </summary>
    public class UserService : BaseService<User>
    {
        public UserService() : this(new UserRepository()) { }

        public UserService(UserRepository userRepository)
        {
            this.UserRepository = userRepository;
            base.Repository = userRepository;
        }

        UserRepository UserRepository
        {
            get;
        }

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

            return UserRepository.GetModel(loginName, passWord);
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

            var temp = GetById(model.Id);
            if (temp == null)
            {
                if (string.IsNullOrWhiteSpace(model.Password))
                    throw new Exception("请输入密码。");

                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                model.Status = EnumUserStatus.Normal;
                UserRepository.Create(model);
            }
            else
            {
                model.Password = string.IsNullOrWhiteSpace(model.Password) ? temp.Password : model.Password;
                model.Status = model.Status == 0 ? temp.Status : model.Status;
                UserRepository.Update(model);
            }
            return model;
        }
        #endregion
    }
}
