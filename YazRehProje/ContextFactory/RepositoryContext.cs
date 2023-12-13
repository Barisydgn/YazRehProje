using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Repositories.Context;
using System.Text;

namespace YazRehProje.ContextFactory
{
    public class RepositoryContext : IDesignTimeDbContextFactory<YazContext>
    {
        public YazContext CreateDbContext(string[] args)
        {
            var configuration=new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var builder = new DbContextOptionsBuilder<YazContext>().UseSqlServer(configuration.GetConnectionString("SqlCon"), prj => prj.MigrationsAssembly("Repositories"));
            return new YazContext(builder.Options);
        }
    }
}
