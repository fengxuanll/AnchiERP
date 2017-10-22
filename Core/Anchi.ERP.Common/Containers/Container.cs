using Anchi.ERP.Common.Configuration;
using Anchi.ERP.Common.GOF;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace Anchi.ERP.Common.Containers
{
    /// <summary>
    /// 容器。包括IOC等
    /// </summary>
    public class Container
    {
        /// <summary>
        /// 
        /// </summary>
        public Container()
        {
            this.UnityContainer = new UnityContainer();
            this.LoadDefaultUnityConfig();
        }

        /// <summary>
        /// Unity容器
        /// </summary>
        public IUnityContainer UnityContainer
        {
            get;
            protected set;
        }

        /// <summary>
        /// 从Unity容器中解析对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T ResolveUnity<T>()
        {
            return this.UnityContainer.Resolve<T>();
        }

        /// <summary>
        /// 加载默认Unity配置
        /// </summary>
        protected void LoadDefaultUnityConfig()
        {
            var dllConfiguration = new DllConfiguration(Constants.UnityConfigFileName);
            var section = dllConfiguration.GetSection("unity") as UnityConfigurationSection;
            this.UnityContainer.LoadConfiguration(section);
        }

        /// <summary>
        /// 容器实例
        /// </summary>
        public static Container Instance
        {
            get
            {
                return Singleton<Container>.Instance;
            }
        }
    }
}
