using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anchi.ERP.Common.Containers
{
    public class ApplicationContext
    {
        [ThreadStatic]
        static IApplicationContext CurrentContext;

        /// <summary>
        /// 获取上下文容器实例。
        /// </summary>
        /// <remarks>
        /// 如果未显示调用 <see cref="SetContainer"/> 方法初始化容器实例，则自动根据应用程序类型初始化为 
        /// <see cref="WCFInvokeContextContainer"/> 或 <see cref="AspNetInvokeContextContainer"/> 或
        /// <see cref="TreadInvokeContextContainer"/>。
        /// </remarks>
        /// <returns></returns>
        public static IApplicationContext GetContext()
        {
            if (CurrentContext == null)
            {
                CurrentContext = new ThreadApplicationContext();
            }

            return CurrentContext;
        }

        /// <summary>
        /// 设置上下文容器实例。
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static void SetContext(IApplicationContext context)
        {
            CurrentContext = context;
        }
    }
}
