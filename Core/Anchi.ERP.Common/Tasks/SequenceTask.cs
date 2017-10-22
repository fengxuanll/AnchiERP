using Anchi.ERP.Common.Logging.Log4net;
using log4net;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Anchi.ERP.Common.Tasks
{
    /// <summary>
    /// 顺序Task
    /// </summary>
    /// <typeparam name="T">附属数据</typeparam>
    /// <typeparam name="I">要顺序处理的对象</typeparam>
    public abstract class SequenceTask<T, I> : ITask
    {
        #region fileds
        public abstract string ID
        {
            get;
        }
        /// <summary>
        /// 附属数据
        /// </summary>
        public T PrimaryData
        {
            get;
            protected set;
        }
        public TaskStatus Status
        {
            get;
            protected set;
        }
        /// <summary>
        /// 调用PrepareData异常最大容忍次数。达到最大值后，终止Task。
        /// </summary>
        public int ErrorMaximum
        {
            get;
            set;
        }
        private Thread Thread = null;
        private ILog Log = null;
        #endregion

        #region cotr

        public SequenceTask(T primaryData) : this(primaryData, null)
        {
            this.Log = LogerManager.GetLogger("TaskContext");
        }

        public SequenceTask(T primaryData, ILog log)
        {
            this.PrimaryData = primaryData;
            this.Log = log;
            this.ErrorMaximum = 50;
            this.Status = new TaskStatus();
        }

        #endregion

        #region methods

        /// <summary>
        /// 中止处理
        /// </summary>
        public void Abort()
        {
            lock (this)
            {
                this.Status.Suspended = true;
            }
            this.Thread = null;
        }

        /// <summary>
        /// 执行Task
        /// </summary>
        public void Execute()
        {
            if (this.Thread == null)
            {
                ThreadPool.QueueUserWorkItem(this.ExecuteThread);
                //this.Thread = new Thread(this.ExecuteThread);
                //this.Thread.IsBackground = true;
                //this.Thread.Start();
                this.Status.StartTime = DateTime.UtcNow;
            }
            else
            {
                this.Log.ErrorFormat("当前线程({0})已经运行中!无需再次Execute", this.Thread.ManagedThreadId);
            }
        }

        ///// <summary>
        ///// 挂起Task
        ///// </summary>
        //public void Suspend()
        //{
        //    lock (this)
        //    {
        //        this.Status.Suspended = true;
        //    }
        //}

        /// <summary>
        /// item处理完成事件
        /// </summary>
        /// <param name="item"></param>
        public virtual void Operated(I item)
        {
        }
        /// <summary>
        /// item处理前事件
        /// </summary>
        /// <param name="item"></param>
        public virtual void Preoperation(I item)
        {
        }
        /// <summary>
        /// item处理中事件
        /// </summary>
        /// <param name="item"></param>
        public abstract void Operating(I item);
        /// <summary>
        /// 准备数据事件
        /// </summary>
        /// <returns></returns>
        public abstract IList<I> PrepareData();

        /// <summary>
        /// 任务完成事件
        /// </summary>
        public event EventHandler Completed;

        public void Dispose()
        {
            this.Completed = null;
        }

        #endregion

        #region private

        /// <summary>
        /// 执行任务前
        /// </summary>
        protected void PreExecute()
        {
            try
            {
                this.OnPreExecute();
            }
            catch (Exception ex)
            {
                this.Log.Error("Task ID:" + this.ID, ex);
            }
        }

        protected virtual void OnPreExecute()
        {
        }

        /// <summary>
        /// 执行进程
        /// </summary>
        private void ExecuteThread(object nothing)
        {
            this.PreExecute();
            int exCount = this.Status.Crculative ? 0 : this.ErrorMaximum;//是否只处理一次
            while (exCount <= this.ErrorMaximum && !this.Status.Suspended)
            {
                Thread.Sleep(100);//避免一直占用cpu
                I currentItem = default(I);//当前正在处理的数据
                IList<I> datas = null;
                bool hasError = false;
                try
                {
                    this.Log.Info("准备数据。Task Id:" + this.ID);
                    datas = this.PrepareData();
                }
                catch (Exception ex)
                {
                    this.Log.Error("获取数据失败。Task Id:" + this.ID, ex);
                    this.OnExcepton(this.PrimaryData, currentItem, ex);
                    exCount++;
                    hasError = true;
                }
                if (hasError)
                    continue;
                if (datas == null || datas.Count == 0)
                {
                    break;//没有数据则结束处理
                }
                foreach (I item in datas)
                {
                    try
                    {
                        currentItem = item;
                        if (this.Status.Suspended)
                        {
                            break;//是否已经中止处理？
                        }
                        this.Status.LastActiveTime = DateTime.UtcNow;
                        this.Preoperation(item);
                        this.Operating(item);
                        this.Operated(item);
                    }
                    catch (Exception ex)
                    {
                        this.Log.Error("处理数据失败。Task ID:" + this.ID, ex);
                        try
                        {
                            this.OnExcepton(this.PrimaryData, currentItem, ex);
                        }
                        catch (Exception ex1)
                        {
                            this.Log.Error("记录异常日志出错。Task ID:" + this.ID, ex1);
                        }
                        exCount++;
                    }
                }

            }
            TaskCompletedReason reason = TaskCompletedReason.Normal;
            if (exCount > this.ErrorMaximum)
            {
                reason = TaskCompletedReason.OutErrorMaximum;
            }
            else if (this.Status.Suspended)
            {
                reason = TaskCompletedReason.Suspended;
            }
            this.Complete(reason);
        }

        /// <summary>
        /// 任务完成
        /// </summary>
        protected void Complete(TaskCompletedReason reason)
        {
            try
            {
                this.Log.Info("任务执行完成。Task Id:" + this.ID);
                this.OnComplete(reason);
                if (Completed != null)
                {
                    this.Completed(this, null);
                }
            }
            catch (Exception ex)
            {
                this.Log.Error("任务执行完成是失败。Task ID:" + this.ID, ex);
                this.OnExcepton(this.PrimaryData, default(I), ex);
            }
        }

        /// <summary>
        /// 任务完成
        /// </summary>
        protected virtual void OnComplete(TaskCompletedReason reason)
        {
        }

        /// <summary>
        /// 异常事件。异常日志已经记录。
        /// </summary>
        /// <param name="primaryData"></param>
        /// <param name="item"></param>
        /// <param name="ex"></param>
        protected virtual void OnExcepton(T primaryData, I item, Exception ex)
        {
        }
        #endregion
    }
}