using IntusRepository;
using IntusRepository.Infrastructure;
using IntusService.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IntusService.Configuration
{
    public static class DependencyExtension
    {
        public static void ServiceIntegration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DBContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("IntusConnection"), sqlOption =>
            {
                sqlOption.EnableRetryOnFailure(15, TimeSpan.FromSeconds(30), null);
                sqlOption.MigrationsAssembly(typeof(DBContext).GetTypeInfo().Assembly.GetName().Name);
            }));
            services.AddAutoMapper(Assembly.GetExecutingAssembly(), Assembly.GetAssembly(typeof(ServiceModelProfile)));

            services.AddTransient<IDataRepository, DataRepository>();
            services.AddScoped<IDataService, DataService>();
        }
    }
}
