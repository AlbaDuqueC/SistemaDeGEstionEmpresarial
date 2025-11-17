using Domain.RepositoriesInterfaces;
using Domain.Entities;
using System.Collections.Generic;

namespace Data.Repositories 
{
    /// <summary>
    /// Provides a repository for managing a collection of <see cref="Persona"/> objects.
    /// </summary>
    /// <remarks>The <see cref="PersonaRepository"/> class offers methods to access and manage a predefined
    /// list of personas. It implements the <see cref="IPersonaRepository"/> interface, providing a concrete
    /// implementation for persona data retrieval.</remarks>
    public class PersonaRepository : IPersonaRepository //INJECTABLE
    {
        #region Attributes

        /// <summary>
        /// Represents a collection of <see cref="Persona"/> objects.
        /// </summary>
        /// <remarks>This list is used to store and manage instances of the <see cref="Persona"/>
        /// class.</remarks>
        private List<Persona> ListaPersonas;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonaRepository"/> class with a predefined list of personas.
        /// </summary>
        /// <remarks>The repository is initialized with a fixed set of personas, each having a unique
        /// identifier, first name, last name, and date of birth. This constructor is useful for scenarios where a
        /// sample dataset is needed for testing or demonstration purposes.</remarks>
        public PersonaRepository()
        {
            ListaPersonas = new List<Persona>
            {
               
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Retrieves the list of all personas.
        /// </summary>
        /// <returns>A list of <see cref="Persona"/> objects representing the personas.</returns>
        public List<Persona> GetListadoPersonas()
        {
            return ListaPersonas;
        }
        #endregion
    }
}

