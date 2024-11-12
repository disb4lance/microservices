using repository;

namespace catalog.extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
           services.AddSqlServer<repositoryContext>(configuration.GetConnectionString("sqlConnection"));

    }
}
