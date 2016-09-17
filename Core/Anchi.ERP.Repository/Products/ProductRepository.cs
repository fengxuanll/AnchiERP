using Anchi.ERP.Domain.Products;
using Anchi.ERP.IRepository.Products;

namespace Anchi.ERP.Repository.Products
{
    /// <summary>
    /// 配件管理仓储层
    /// </summary>
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
    }
}
