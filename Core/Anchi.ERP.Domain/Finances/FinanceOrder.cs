using Anchi.ERP.Domain.Finances.Enum;
using System;

namespace Anchi.ERP.Domain.Finances
{
    /// <summary>
    /// 财务收付款明细
    /// </summary>
    public class FinanceOrder : BaseDomain
    {
        /// <summary>
        /// 关联信息ID
        /// </summary>
        public Guid RelationId
        {
            get; set;
        }

        /// <summary>
        /// 财务类型
        /// </summary>
        public EnumFinanceOrderType Type
        {
            get; set;
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get; set;
        }
    }
}
