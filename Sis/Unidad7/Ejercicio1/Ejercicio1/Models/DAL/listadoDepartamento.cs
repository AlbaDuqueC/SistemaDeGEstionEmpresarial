using Ejercicio1.Models.Entities;

namespace Ejercicio1.Models.DAL
{
    public class listadoDepartamento
    {

        public static List<Departamento> GetDepartamentos()
        {

            return new List<Departamento>
            {
                new Departamento(1, "Recursos Humanos"),
                new Departamento(2, "Desarrollo"),
                new Departamento(3, "Marketing"),
                new Departamento(4, "Ventas"),
                new Departamento(5, "Atención al Cliente"),
                

            };
        }

    }
}
