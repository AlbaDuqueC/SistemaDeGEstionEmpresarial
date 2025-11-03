using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PersonaRepositoryEmpty : IPersonaRepository
    {
        public List<Persona> getListaPersonas()
        {
           return ListaPersonas();
        }

        /// <summary>
        /// Método sin parámetros que se encarga de simular una llamada
        /// a una API o BBDD.
        /// </summary>
        /// <returns>Una lista con personas</returns>
        private List<Persona> ListaPersonas()
        {

            return [
                    
                ];

        }
    }
}
