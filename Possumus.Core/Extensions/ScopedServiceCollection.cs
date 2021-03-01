using Microsoft.Extensions.DependencyInjection;
using Possumus.Core.Interfaces;
using Possumus.Core.Services;

namespace Possumus.Core.Extensions
{
    public static class ScopedServiceCollection
    {
        public static IServiceCollection AddCoreScopedServices(this IServiceCollection services)
        {
           services.AddScoped<ICandidatoServices, CandidatoServices>();
            return services;
        }
    }
}