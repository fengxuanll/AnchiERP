using System;
using System.Collections;
using System.Security.Principal;
using System.Threading;

namespace Anchi.ERP.Common.Containers
{
    public class ThreadApplicationContext : ApplicationContextBase
    {
        [ThreadStatic]
        public static Hashtable dataBag = null;

        private Hashtable DataBag
        {
            get
            {
                if (dataBag == null)
                {
                    dataBag = new Hashtable();
                }
                return dataBag;
            }
        }

        public override object GetData(string name)
        {
            object data = null;
            if (this.DataBag.Contains(name))
            {
                data = this.DataBag[name];
            }
            return data;
        }

        public override T GetData<T>(string name)
        {
            var data = this.GetData(name);
            if (data == null)
                return default(T);

            return (T)data;
        }

        public override void SetData(string name, object data)
        {
            this.DataBag[name] = data;
        }

        public override IPrincipal IPrincipal
        {
            get
            {
                return Thread.CurrentPrincipal;
            }
            set
            {
                Thread.CurrentPrincipal = value;
            }
        }
    }
}
