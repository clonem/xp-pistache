using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using xp.pistache.core.Infra.Validations;

namespace xp.pistache.core.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddAplicatioinServices(this IServiceCollection services)
        {
            // Registra todos os validadores que estão no mesmo assembly
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Adiciona o ValidationBehaviour ao pipeline do MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //configuration.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            });



            // services.AddScoped<IClientRepository, ClientRepository>();

            return services;
        }
    }
}
