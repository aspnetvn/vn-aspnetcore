using System.Collections;
using System.Collections.Generic;

namespace AppName.Core.Entities
{
    public class Category : Base.Entity
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; } 

        public static Category Create(int categoryId, string name, string description = null)
        {
            return new Category
            {
                Id = categoryId,
                Name = name,
                Description = description
            };
        } 
    }
}
