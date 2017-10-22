using Anchi.ERP.Common.Logging.Log4net;
using log4net;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Anchi.ERP.Common.Tasks
{
    /// <summary>
    /// Task上下文对象
    /// </summary>
    public class TaskContext
    {
        Dictionary<Type, Dictionary<string, ITask>> Tasks = new Dictionary<Type, Dictionary<string, ITask>>();
        protected TaskContext()
        {
            this.Log = LogerManager.GetLogger("TaskContext");
        }

        /// <summary>
        /// 全部任务完成事件
        /// </summary>
        public event EventHandler AllTaskCompleted;

        static object objLock = new object();
        static TaskContext current = null;
        public static TaskContext Current
        {
            get
            {
                if (current == null)
                {
                    lock (objLock)
                    {
                        if (current == null)
                        {
                            current = new TaskContext();
                        }
                    }
                }
                return current;
            }
        }
        protected ILog Log
        {
            get;
            set;
        }
        /// <summary>
        /// 线程同步管理
        /// </summary>
        ManualResetEvent manualResetEvent = new ManualResetEvent(true);

        public ITask GetTask(Type taskType, string id)
        {
            if (this.Tasks.ContainsKey(taskType) && this.Tasks[taskType].ContainsKey(id))
            {
                return this.Tasks[taskType][id];
            }
            return null;
        }

        /// <summary>
        /// 终止Task，且会从Context移除掉。
        /// </summary>
        /// <param name="task"></param>
        public void AbortTask(ITask task)
        {
            task.Abort();
            this.RemoveTaskFromContext(task);
        }
        /// <summary>
        /// 开始执行Task，且会把Task附加到Context。
        /// </summary>
        /// <param name="task"></param>
        public void StartTask(ITask task)
        {
            if (this.AddTaskToContext(task))
            {
                task.Execute();
                this.manualResetEvent.Reset();
            }
        }

        /// <summary>
        /// 阻止当前线程，直到当前 System.Threading.WaitHandle 收到信号，同时使用 32 位带符号整数测量时间间隔。
        /// 等待所有任务完成，否则一直阻塞。
        /// </summary>
        /// <param name="millisecondsTimeout">
        /// 等待的毫秒数，或为 System.Threading.Timeout.Infinite (-1)，表示无限期等待。
        /// </param>
        /// <returns>
        /// 如果当前实例收到信号，则为 true；否则为 false。
        /// true：所有任务完成，正常退出。
        /// false：等待超时退出。
        /// </returns>
        public bool Wait(int millisecondsTimeout = System.Threading.Timeout.Infinite)
        {
            return this.manualResetEvent.WaitOne(millisecondsTimeout);
        }

        #region protectd
        protected void RemoveTaskFromContext(ITask task)
        {
            if (task == null)
                return;
            Type taskType = task.GetType();
            if (this.Tasks.ContainsKey(taskType))
            {
                if (this.Tasks[taskType].ContainsKey(task.ID))
                {
                    this.Tasks[taskType].Remove(task.ID);
                }
                if (this.Tasks[taskType].Count == 0)
                {
                    this.Tasks.Remove(taskType);
                }
            }
            if (this.Tasks.Count == 0)
            {
                this.OnAllTaskCompleted(null);
            }
        }

        /// <summary>
        /// 所有任务都结束
        /// </summary>
        /// <param name="e"></param>
        protected void OnAllTaskCompleted(EventArgs e)
        {
            if (this.AllTaskCompleted != null)
            {
                try
                {
                    this.AllTaskCompleted(this, e);
                }
                catch (Exception ex)
                {
                    this.Log.Error("TaskContext.AllTaskCompleted发生异常", ex);
                }
            }
            this.manualResetEvent.Set();
        }

        protected bool AddTaskToContext(ITask task)
        {
            if (task == null)
                return false;
            Type taskType = task.GetType();
            if (!this.Tasks.ContainsKey(taskType))
            {
                this.Tasks[taskType] = new Dictionary<string, ITask>();
            }
            if (this.Tasks.ContainsKey(taskType) && this.Tasks[taskType].ContainsKey(task.ID))
            {
                this.Log.ErrorFormat("{0}已经存在相同ID的Task！", task.ID);
                return false;
            }
            this.Tasks[taskType][task.ID] = task;
            task.Completed += Task_Completed;
            return true;
        }

        void Task_Completed(object sender, EventArgs e)
        {
            ITask task = sender as ITask;
            this.RemoveTaskFromContext(task);
            task.Dispose();
        }
        #endregion
    }
}