using Anchi.ERP.Common.Security;
using Anchi.ERP.Domain.Users;
using Anchi.ERP.Domain.Users.Enum;
using Anchi.ERP.Domain.Users.Filter;
using Anchi.ERP.IRepository.Users;
using Anchi.ERP.Repository.Users;
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
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            this.UserRepository = userRepository;
        }

        IUserRepository UserRepository { get; }
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

            var temp = this.Get(model.Id);
            if (temp == null)
            {
                if (string.IsNullOrWhiteSpace(model.Password))
                    throw new Exception("请输入密码。");

                model.Password = MD5.GetMd5Value(model.Password);
                model.Id = model.Id == Guid.Empty ? Guid.NewGuid() : model.Id;
                model.CreatedOn = DateTime.Now;
                model.Status = EnumUserStatus.Normal;
                this.UserRepository.Create(model);
            }
            else
            {
                temp.TrueName = model.TrueName;
                temp.LoginName = model.LoginName;

                if (!string.IsNullOrWhiteSpace(model.Password))
                    temp.Password = MD5.GetMd5Value(model.Password);

                temp.IDCard = model.IDCard;
                temp.Tel = model.Tel;
                temp.Address = model.Address;
                temp.Remark = model.Remark;

                this.UserRepository.Update(temp);
            }
            return model;
        }
        #endregion
    }
}
