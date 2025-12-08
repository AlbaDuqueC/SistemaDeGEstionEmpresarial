using Domain.dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.UseCase
{
    public interface IPersonaRepositoryUseCase
    {

        public List<PersonaConNombreDepartamento> getListaPersonasConNombreDepartameto();
        public PersonaConListadoDepartamento getPersonaConListadoDepartamento(int id);
        public PersonaConNombreDepartamento getPersonaConNombreDepartamento(int id);
        public int crearPersona(Persona personaNueva);
        public int actualizarPersona(int idPersona, Persona personaActualizada);
        public int eliminarPersona(int idPersona);
        PersonaConNombreDepartamento getPersonaConNombreDepartamento();
        List<PersonaConListadoDepartamento> getPersonaConListadoDepartamento();
    }
}
