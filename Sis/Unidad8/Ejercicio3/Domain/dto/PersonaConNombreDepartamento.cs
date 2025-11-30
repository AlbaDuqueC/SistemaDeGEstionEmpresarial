using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.dto
{
    public class PersonaConNombreDepartamento
    {
        public Persona Persona { get; private set; }
        public string NombreDepartamento { get; private set; }

        public PersonaConNombreDepartamento(Persona persona, IDepartamentoRepository repoDepartamentos)
        {
            Persona = persona;
            NombreDepartamento = repoDepartamentos.getDepartamentoPorId(persona.IdDepartamento)?.Nombre;
        }
    }
}
