using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AppName.Infrastructure.Data
{
    public class AppNameContextFactory : IDesignTimeDbContextFactory<AppNameContext>
    {
        public AppNameContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppNameContext>();
            optionsBuilder.UseSqlServer("Server=AspnetVietNam;Database=AppNameDb;User Id=sa;Password=123456a@A;");

            return new AppNameContext(optionsBuilder.Options);
        }
    }
}
