using Anchi.ERP.Common.Filter;
using System;
using System.Text;

namespace Anchi.ERP.Domain.Products.Filter
{
    public class FindProductStockRecordFilter : PagedQueryFilter
    {
        public override string SQL
        {
            get
            {
                var sb = new StringBuilder();

                return sb.ToString();
            }
        }

        public string Code
        {
            get; set;
        }

        public string Name
        { get; set; }

        public DateTime? RecordOn
        { get; set; }
    }
}
