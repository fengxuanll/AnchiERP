using Anchi.ERP.Domain.Finances;
using Anchi.ERP.Domain.Sequences.Enum;
using Anchi.ERP.IRepository.Finances;
using Anchi.ERP.Repository.Sequences;
using System;

namespace Anchi.ERP.Repository.Finances
{
    /// <summary>
    /// 财务单仓储层实现
    /// </summary>
    public class FinanceOrderRepository : BaseRepository<FinanceOrder>, IFinanceOrderRepository
    {
        #region 生成财务单编码
        /// <summary>
        /// 生成财务单编码
        /// </summary>
        /// <returns></returns>
        public string GetSequenceNextCode()
        {
            return string.Format("FO-{0}{1}", DateTime.Now.ToString("yyyyMMdd"), SequenceRepository.Instance.GetNextValue(EnumSequenceType.Finance).ToString("0000"));
        }
        #endregion
    }
}
