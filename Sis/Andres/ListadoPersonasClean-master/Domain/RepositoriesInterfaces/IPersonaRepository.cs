using System.Collections.Generic;
using Domain.Entities;


namespace Domain.RepositoriesInterfaces
{
    /// <summary>
    /// Defines a repository interface for accessing and managing persona data.
    /// </summary>
    public interface IPersonaRepository 
    {
        /// <summary>
        /// Retrieves a list of all registered persons.
        /// </summary>
        /// <returns>A list of <see cref="Persona"/> objects representing all registered persons. The list will be empty if no
        /// persons are registered.</returns>
        List<Persona> GetListadoPersonas();
    }
}
