using Domain.dto;
using Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio3.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaWithNombreDepartamentoDtoController : ControllerBase
    {
        private readonly IPersonaRepositoryUseCase _personasUseCase;

        public PersonaWithNombreDepartamentoDtoController(IPersonaRepositoryUseCase personasUseCase)
        {
            _personasUseCase = personasUseCase;
        }

        // GET: api/<PersonaWithNombreDepartamentoDto>
        [HttpGet]
        public IActionResult Get()
        {
            IActionResult salida;
            List<PersonaConNombreDepartamento> lista = new List<PersonaConNombreDepartamento>();

            try
            {
                List<PersonaConNombreDepartamento> getListaPersonasConNombreDepartameto = _personasUseCase.getListaPersonasConNombreDepartameto();
                lista = getListaPersonasConNombreDepartameto;
                if (lista.Count > 0)
                {
                    salida = NoContent();
                }
                else
                {
                    salida = Ok(lista);
                }
            }
            catch
            {
                salida = BadRequest();
            }

            return salida;
        }

        // GET api/<PersonaWithNombreDepartamentoDto>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            PersonaConListadoDepartamento personaWNDpto;
            IActionResult salida;

            try
            {
                personaWNDpto = _personasUseCase.getPersonaConListadoDepartamento(id);
                salida = Ok(personaWNDpto);
            }
            catch
            {
                salida = NotFound();
            }
            return salida;
        }
    }
}