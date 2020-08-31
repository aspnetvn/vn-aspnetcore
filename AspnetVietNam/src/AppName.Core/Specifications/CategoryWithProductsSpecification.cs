using AppName.Core.Entities;
using AppName.Core.Specifications.Base;

namespace AppName.Core.Specifications
{
    public sealed class CategoryWithProductsSpecification : BaseSpecification<Category>
    {
        public CategoryWithProductsSpecification(int categoryId) : base(b => b.Id == categoryId)
        {
            AddInclude(b => b.Products);
        }
    }
}
