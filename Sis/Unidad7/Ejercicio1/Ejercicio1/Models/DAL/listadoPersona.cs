using Ejercicio1.Models.Entities;

namespace Ejercicio1.Models.DAL
{
    public class listadoPersona
    {

        public static List<Persona> getPersonas()
        {

            return new List<Persona>
            {
                new Persona(1, "Ana", 12, 1),
                new Persona(2, "Juan", 23, 2),
                new Persona(3, "Luis", 45, 3),
                new Persona(4, "Marta", 22, 4),
                new Persona(5, "Carlos", 23, 5),
                new Persona(6, "Laura", 32, 1)


            };
        }

        /// <summary>
        /// Retrieves a <see cref="Persona"/> object from the specified position in the collection.
        /// pre: Posicion debe de ser mayor a 0 y menor a 7
        /// </summary>
        /// <param name="posicion">The zero-based index of the <see cref="Persona"/> to retrieve. Must be within the bounds of the collection.</param>
        /// <returns>The <see cref="Persona"/> object at the specified position in the collection.</returns>
        public static Persona GetPersona(int posicion)
        {

            return getPersonas()[posicion];

        }
    }
}
