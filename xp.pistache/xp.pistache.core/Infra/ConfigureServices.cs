using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Reflection;
using xp.pistache.core.Domain.Interfaces;
using xp.pistache.core.Infra.Repositories;

namespace xp.pistache.core.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Automapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            // DB
            services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IDbRepository, DapperRepository>();


            return services;
        }
    }
}
