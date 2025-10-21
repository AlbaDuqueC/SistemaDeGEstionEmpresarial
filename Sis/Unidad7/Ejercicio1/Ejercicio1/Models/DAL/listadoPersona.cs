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
    }
}
