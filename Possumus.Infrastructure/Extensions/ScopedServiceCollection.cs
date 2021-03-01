using Microsoft.Extensions.DependencyInjection;

namespace Possumus.Infrastructure.Extensions
{
    public static class ScopedServiceCollection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
