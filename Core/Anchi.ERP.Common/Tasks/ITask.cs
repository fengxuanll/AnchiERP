using System;

namespace Anchi.ERP.Common.Tasks
{
    /// <summary>
    /// 任务接口
    /// </summary>
    public interface ITask : IDisposable
    {
        /// <summary>
        /// Task ID
        /// </summary>
        string ID { get; }

        /// <summary>
        /// 状态
        /// </summary>
        TaskStatus Status { get; }

        /// <summary>
        /// 中止任务
        /// </summary>
        void Abort();

        /// <summary>
        /// 执行任务
        /// </summary>
        void Execute();

        event EventHandler Completed;
    }
}
