using Data.Repositories;
using Domain.Repositories;
using Domain.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CompositionRoot
{
    public static class Container
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<Domain.Interfaces.IPersonaRepositoryUseCase, DefaultGetListadoUseCase>();

            return services;
        }

    }
}
