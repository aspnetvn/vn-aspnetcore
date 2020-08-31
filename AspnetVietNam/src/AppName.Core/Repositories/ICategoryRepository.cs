using AppName.Core.Entities;
using AppName.Core.Repositories.Base;
using System.Threading.Tasks;

namespace AppName.Core.Repositories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
}
