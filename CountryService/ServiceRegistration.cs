using CountryService.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CountryService
{
    public static class ServiceRegistration
    {
        public static void AddInfraLayer(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDBContext(configuration);
        }
        public static void AddDBContext(this IServiceCollection services,IConfiguration configuration)
        {
            var connstring = configuration.GetConnectionString("DefaultConnnection");
            services.AddDbContext<CountryContext>(options=>options.UseSqlServer(connstring,builder=>builder.MigrationsAssembly(typeof(CountryContext).Assembly.FullName)));
        }
    }
}
