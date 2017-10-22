using Anchi.ERP.Domain.Users;
using Anchi.ERP.Resource;

namespace Anchi.ERP.UI.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// 当前登录用户
        /// </summary>
        public User User
        {
            get
            {
                return Anchi.ERP.Common.Containers.ApplicationContext.GetContext().GetData<User>(Constants.CurrentUser);
            }
        }
    }
}
