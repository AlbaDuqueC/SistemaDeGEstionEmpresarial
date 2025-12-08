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
        private  IPersonaRepository _repositorioPersonas;
        private  IDepartamentoRepository _repositorioDepartamentos;

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
            var listaDepartamentos = _repositorioDepartamentos.getListaDepartamentos();
            var listaConNombre = new List<PersonaConNombreDepartamento>();



            foreach (var p in lista)

                foreach (var d in listaDepartamentos)
                {
                    if (p.IdDepartamento == d.ID)
                    {
                        listaConNombre.Add(new PersonaConNombreDepartamento(p, d.Nombre, listaDepartamentos));
                        break;
                    }
                }

            return listaConNombre;
        }

        public PersonaConListadoDepartamento getPersonaConListadoDepartamento(int id)
        {

            var persona = _repositorioPersonas.getPersonaPorId(id);
            return new PersonaConListadoDepartamento(persona, _repositorioDepartamentos.getListaDepartamentos());
        }

        public PersonaConNombreDepartamento getPersonaConNombreDepartamento(int id)
        {
            var persona = _repositorioPersonas.getPersonaPorId(id);
            var departamento = _repositorioDepartamentos.getDepartamentoPorId(persona.IdDepartamento);
            var listaDepartamentos = _repositorioDepartamentos.getListaDepartamentos();
            return new PersonaConNombreDepartamento(persona, departamento.Nombre, listaDepartamentos);
        }

        public int crearPersona(Persona personaNueva)
        { 
            return _repositorioPersonas.crearPersona(personaNueva); 
        }

        public int actualizarPersona(int idPersona, Persona personaActualizada)
        { return _repositorioPersonas.actualizarPersona(idPersona, personaActualizada); 
        }

        public int eliminarPersona(int idPersona)
        { return _repositorioPersonas.eliminarPersona(idPersona); }


        //HAY QUE ARREGLAR ESTOS MÉTODOS SIN PARÁMETROS QUE NO TIENEN SENTIDO
        public PersonaConNombreDepartamento getPersonaConNombreDepartamento()
        {
            // Utiliza el idPersonaSeleccionada previamente establecido
            var persona = _repositorioPersonas.getPersonaPorId(_idPersonaSeleccionada);
            if (persona == null) return null;

            var departamento = _repositorioDepartamentos.getDepartamentoPorId(persona.IdDepartamento);
            var listaDepartamentos = _repositorioDepartamentos.getListaDepartamentos();

            return new PersonaConNombreDepartamento(persona, departamento?.Nombre, listaDepartamentos);
        }

        public PersonaConListadoDepartamento getPersonaConListadoDepartamentoPorId(int idPersona)
        {
            Persona persona = _repositorioPersonas.getPersonaPorId(idPersona);
            if (persona == null) return null;

            return new PersonaConListadoDepartamento(persona, _repositorioDepartamentos.getListaDepartamentos());
        }

        public List<PersonaConListadoDepartamento> getPersonaConListadoDepartamento()
        {
           
            var listaPersonas = _repositorioPersonas.getListaPersonas();
            var listaDepartamentos = _repositorioDepartamentos.getListaDepartamentos();
            var listaConListado = new List<PersonaConListadoDepartamento>();
            foreach (var persona in listaPersonas)
            {
                listaConListado.Add(new PersonaConListadoDepartamento(persona, listaDepartamentos));
            }
            return listaConListado;
        }
    } 
}
