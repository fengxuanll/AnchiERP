using System.Security.Principal;

namespace Anchi.ERP.Common.Containers
{
    public interface IApplicationContext
    {
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object GetData(string name);
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        T GetData<T>(string name);
        /// <summary>
        /// 放置数据
        /// </summary>
        /// <param name="name"></param>
        /// <param name="data"></param>
        void SetData(string name, object data);

        /// <summary>
        /// 当前登录用户的基本信息
        /// </summary>
        IPrincipal IPrincipal { get; set; }
    }
}
