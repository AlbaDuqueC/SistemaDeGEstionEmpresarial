using Ejercicio1.Models.Entities;
using Ejercicio1.Models.DAL;

namespace Ejercicio1.Models.ViewModel
{
    public class Ejercicio4EditarPersonaVM
    {

        private Persona _persona;
        private List<Departamento> _departamentos;

        public Persona persona
        {
            get { return _persona; }
            set { _persona = value; }
        }

        public List<Departamento> departamentos
        {
            get { return _departamentos; }
        }

        public Ejercicio4EditarPersonaVM(int posicionPersona)
        {
            _persona = listadoPersona.GetPersona(posicionPersona);
            _departamentos = listadoDepartamento.GetDepartamentos();
        }
        public Ejercicio4EditarPersonaVM()
        {
            Random rand = new Random();
            int posicionPersona = rand.Next(listadoPersona.getPersonas().Count);
            _persona = listadoPersona.GetPersona(posicionPersona);
            _departamentos = listadoDepartamento.GetDepartamentos();
        }

    }
}
