using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using repository;

namespace catalog
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<repositoryContext>
    {
        public repositoryContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<repositoryContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                       b => b.MigrationsAssembly("catalog"));

            return new repositoryContext(builder.Options);
        }
    }
}
