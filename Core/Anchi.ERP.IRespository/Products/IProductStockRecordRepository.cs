using Anchi.ERP.Domain.Products;
using Anchi.ERP.IRespository;

namespace Anchi.ERP.IRepository.Products
{
    /// <summary>
    /// 配件出入库明细仓储层接口
    /// </summary>
    public interface IProductStockRecordRepository : IBaseRepository<ProductStockRecord>
    {
    }
}
