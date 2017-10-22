using Anchi.ERP.Domain.Users;

namespace Anchi.ERP.UI.Views
{
    public partial class BaseWindow : Fluent.RibbonWindow
    {
        public User CurrentUser
        { get; set; }
    }
}
