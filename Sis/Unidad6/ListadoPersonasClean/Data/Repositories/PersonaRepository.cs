using Domain.Entities;
using Domain.Repositories;

namespace Data.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        /// <summary>
        /// Método sin parámetros que se encarga de simular una llamada
        /// a una API o BBDD.
        /// </summary>
        /// <returns>Una lista con personas</returns>
        private List<Persona> ListaPersonas()
        {

            return [
                    new Persona(1, "Juan", "Pérez", 23),
                new Persona(2, "Ana", "García", 30),
                new Persona(3, "Luis", "Martínez", 25),
                new Persona(4, "Marta", "López", 28),
                new Persona(5, "Carlos", "Sánchez", 40),
                new Persona(6, "Lucía", "Fernández", 22),
                new Persona(7, "Diego", "Torres", 35),
                new Persona(8, "Sofía", "Ruiz", 27),
                new Persona(9, "Miguel", "Vargas", 31),
                new Persona(10, "Elena", "Navarro", 29)
                ];

        }

        /// <summary>
        /// Método que sirve para devolver un listado de personas
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas()
        {
            return ListaPersonas();
        }

        
    }
}
