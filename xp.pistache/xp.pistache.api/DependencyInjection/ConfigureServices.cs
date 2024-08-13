using System.Diagnostics.CodeAnalysis;
using xp.pistache.api.Filters;

namespace xp.pistache.api.DependencyInjection
{
    [ExcludeFromCodeCoverage]
    public static class ConfigureServices
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionHandlerFilter>();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
