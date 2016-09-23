using Anchi.ERP.Domain.Sequences.Enum;

namespace Anchi.ERP.IRepository.Sequences
{
    /// <summary>
    /// 序列仓储层接口
    /// </summary>
    public interface ISequenceRepository
    {
        /// <summary>
        /// 获取序列的下一个值
        /// </summary>
        /// <param name="sequenceType"></param>
        /// <returns></returns>
        long GetNextValue(EnumSequenceType sequenceType);
    }
}
