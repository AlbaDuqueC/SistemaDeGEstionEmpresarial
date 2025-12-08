using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IPersonaRepository
    {
        public List<Persona> getListaPersonas();
        public Persona getPersonaPorId(int id);

        public int crearPersona(Persona personaNueva);

        public int actualizarPersona(int idPersona, Persona persona);

        public int eliminarPersona(int idPersona);
        Persona getPersonaById(int idPersona);
        IEnumerable<Departamento> getListaDepartamento();
    }
}
