using Data.Repositories.repositoriosdepartamento;
using Data.Repositories.repositoriospersona;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCase;
using Domain.UseCase;
using Microsoft.Extensions.DependencyInjection;

namespace Container
{
    public static class DI
    {

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            // Repositorios
            services.AddScoped<IPersonaRepository, PersonaRepositoryAzure>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepositoryAzure>();

            // Use Cases
            services.AddScoped<IPersonaRepositoryUseCase, PersonaRepositoryUseCase>();
            services.AddScoped<IDepartamentoRepositoryUseCase, DepartamentoRepositoryUseCase>();
        }

    }
}
