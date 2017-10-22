using System.Security.Principal;

namespace Anchi.ERP.Common.Containers
{
    public abstract class ApplicationContextBase : IApplicationContext
    {
        public abstract object GetData(string name);

        public abstract T GetData<T>(string name);

        public abstract void SetData(string name, object data);

        public abstract IPrincipal IPrincipal
        {
            get;
            set;
        }
    }
}
