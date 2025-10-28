using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class PersonasListVM
    {
        // Atributos privados
        private List<Persona> _personasList;
        private Persona _personaSeleccionada;

        private readonly IRepositoryPersonas _repositoryPersonas;

        // Constructor con inyección de dependencias
        public PersonasListVM(IRepositoryPersonas repositoryPersonas)
        {
            _repositoryPersonas = repositoryPersonas;

            _personaSeleccionada = new Persona(0, string.Empty, string.Empty);

            _personasList = _repositoryPersonas.GetListadoCompletoPersonas();
        }

        // Propiedad de solo lectura
        public List<Persona> PersonasList
        {
            get { return _personasList; }
        }

        // Propiedad lectura/escritura
        public Persona PersonaSeleccionada
        {
            get { return _personaSeleccionada; }
            set { _personaSeleccionada = value; }
        }
    }
}
