using AppName.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppName.Infrastructure.Data
{
    public class AppNameContext : DbContext
    {
        public AppNameContext(DbContextOptions<AppNameContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>(ConfigProduct);
            builder.Entity<Category>(ConfigCategory);
        }

        private void ConfigCategory(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id)
               .UseHiLo("aspnetvn_type_hilo")
               .IsRequired();
            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(100);
        }

        private void ConfigProduct(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.Id)
                .UseHiLo("aspnetvn_type_hilo")
                .IsRequired();
            builder.Property(cb => cb.ProductName)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}
