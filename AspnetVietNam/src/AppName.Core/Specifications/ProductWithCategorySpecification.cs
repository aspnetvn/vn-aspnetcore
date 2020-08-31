using AppName.Core.Entities;
using AppName.Core.Specifications.Base;

namespace AppName.Core.Specifications
{
    public sealed class ProductWithCategorySpecification : BaseSpecification<Product>
    {
        public ProductWithCategorySpecification() : base(null)
        {
            AddInclude(b => b.Category);
        }

        public ProductWithCategorySpecification(string productName): base(b => b.ProductName.ToLower().Contains(productName.ToLower()))
        {
            AddInclude(b => b.Category);
        }
    }
}
