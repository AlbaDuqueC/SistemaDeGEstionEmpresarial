namespace Container
{
    public class Container
    {
        public static IServiceCollection AddCompositionRoot (this IServiceCollection services, IConfiguration configuration)
        {
           services.AddScoped<IRepositoryMision, RepositoryMision>();
            servicesAddScoped<IUseCaseListadoMisiones, ListadoMisionesUseCase>();

            return services;
        }
    }
}
