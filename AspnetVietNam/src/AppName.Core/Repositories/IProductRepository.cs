using AppName.Core.Entities;
using AppName.Core.Repositories.Base;
using System.Linq;
using System.Threading.Tasks;

namespace AppName.Core.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IQueryable<Product>> GetProductListAsync();
        Task<IQueryable<Product>> GetProductByNameAsync(string productName);
        Task<IQueryable<Product>> GetProductByCategoryAsync(int categoryId);
    }
}
