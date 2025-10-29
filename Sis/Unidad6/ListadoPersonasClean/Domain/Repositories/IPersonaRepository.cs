using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{/// <summary>
 /// Interfaz de repositorio de persona que será implementada por los
 /// repositorios de la carpeta DATA para que los métodos que se encuentran
 /// dentro de estos puedan ser usados en otras clases fuera de DATA.
 /// </summary>
    public interface IPersonaRepository
    {
        /// <summary>
        /// Método que se tendrá que implementar en donde se inyecte para
        /// poder hacer uso de los métodos listado de personas
        /// de los repositorios
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas();
    }
}
