using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace CompositionRoot
{
    public class Container
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPersonaRepository, Data.Repositories.PersonaRepository>();
            services.AddScoped<Domain.Interfaces.IPersonaRepositoryUseCase, PersonaRepositoryUseCase>();

            return services;
        }

    }
}
