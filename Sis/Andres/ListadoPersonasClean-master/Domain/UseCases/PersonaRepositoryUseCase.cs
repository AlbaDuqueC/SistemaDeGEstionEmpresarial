using Domain.Entities;
using Domain.RepositoriesInterfaces;


namespace Domain.UseCases
{
    public class PersonaRepositoryUseCase : IPersonaRepositoryUseCase
    {
        private IPersonaRepository PersonaRepository;
        public PersonaRepositoryUseCase( IPersonaRepository personaRepository) // INJECTION
        {
            this.PersonaRepository = personaRepository;
        }
       
        public List<Persona> GetListadoPersonas()
        {
            return PersonaRepository.GetListadoPersonas();
        }
    }
}