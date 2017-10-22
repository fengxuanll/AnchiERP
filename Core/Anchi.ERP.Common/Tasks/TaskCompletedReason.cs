namespace Anchi.ERP.Common.Tasks
{
    /// <summary>
    /// 任务完的原因
    /// </summary>
    public enum TaskCompletedReason
    {
        /// <summary>
        /// 正常结束
        /// </summary>
        Normal = 0,

        /// <summary>
        /// 超过最大错误数量
        /// </summary>
        OutErrorMaximum = 1,

        /// <summary>
        /// 人为挂起
        /// </summary>
        Suspended = 2,
    }
}
