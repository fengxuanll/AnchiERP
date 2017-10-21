namespace Anchi.ERP.Common.GOF
{
    public class Singleton<T> where T : new()
    {
        static T instance;
        static object lockObj = new object();

        /// <summary>
        /// 单例
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
