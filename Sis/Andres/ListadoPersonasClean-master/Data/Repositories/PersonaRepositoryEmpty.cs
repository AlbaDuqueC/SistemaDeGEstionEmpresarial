using Domain.RepositoriesInterfaces;
using Domain.Entities;

namespace Data.Repositories
{
    /// <summary>
    /// Provides a repository for managing a collection of <see cref="Persona"/> objects.
    /// </summary>
    /// <remarks>This class implements the <see cref="IPersonaRepository"/> interface and is initialized with
    /// an empty list of personas. It is intended for use in scenarios where a sample dataset is needed for testing or
    /// demonstration purposes.</remarks>
    public class PersonaRepositoryEmpty : IPersonaRepository //INJECTABLE
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
        /// Initializes a new instance of the <see cref="PersonaRepositoryEmpty"/> class.
        /// </summary>
        /// <remarks>This constructor initializes the <see cref="ListaPersonas"/> property to an empty
        /// list of <see cref="Persona"/> objects.</remarks>
        public PersonaRepositoryEmpty()
        {
            ListaPersonas = new List<Persona> {};
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

