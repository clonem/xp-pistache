using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace xp.pistache.core.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAplicatioinServices(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });



            // services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
