using Microsoft.Extensions.DependencyInjection;
using Domain.RepositoriesInterfaces;
using Data.Repositories;
using Domain.UseCases;

namespace DI
{
    public static class Container
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services)
        {
            services.AddScoped<IPersonaRepository, PersonaRepositoryAzure>();
            services.AddScoped<IPersonaRepositoryUseCase, PersonaRepositoryUseCase>();
            return services;
        }
    }
}
