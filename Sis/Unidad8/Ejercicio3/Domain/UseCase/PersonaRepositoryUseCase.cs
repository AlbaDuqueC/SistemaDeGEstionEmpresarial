using Domain.dto;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public class PersonaRepositoryUseCase : IPersonaRepositoryUseCase
    {
        private readonly IPersonaRepository _repositorioPersonas;
        private readonly IDepartamentoRepository _repositorioDepartamentos;

        private int _idPersonaSeleccionada;  

        public PersonaRepositoryUseCase(
            IPersonaRepository personaRepository,
            IDepartamentoRepository departamentoRepository)
        {
            _repositorioPersonas = personaRepository;
            _repositorioDepartamentos = departamentoRepository;
        }

        // El controlador establecerá este valor ANTES de pedir datos
        public void setIdPersona(int idPersona)
        {
            _idPersonaSeleccionada = idPersona;
        }

        public List<PersonaConNombreDepartamento> getListaPersonasConNombreDepartameto()
        {
            var lista = _repositorioPersonas.getListaPersonas();
            List<PersonaConNombreDepartamento> result = new();

            foreach (var p in lista)
                result.Add(new PersonaConNombreDepartamento(p, _repositorioDepartamentos));

            return result;
        }

        public PersonaConListadoDepartamento getPersonaConListadoDepartamento(int id)
        {

            var persona = _repositorioPersonas.getPersonaPorId(id);
            return new PersonaConListadoDepartamento(persona, _repositorioDepartamentos);

        }

        public PersonaConNombreDepartamento getPersonaConNombreDepartamento(int id)
        {
            var persona = _repositorioPersonas.getPersonaPorId(id);
            return new PersonaConNombreDepartamento(persona, _repositorioDepartamentos);
        }

        public int crearPersona(Persona personaNueva)
            => _repositorioPersonas.crearPersona(personaNueva);

        public int actualizarPersona(int idPersona, Persona personaActualizada)
            => _repositorioPersonas.actualizarPersona(idPersona, personaActualizada);

        public int eliminarPersona(int idPersona)
            => _repositorioPersonas.eliminarPersona(idPersona);


    }
}
