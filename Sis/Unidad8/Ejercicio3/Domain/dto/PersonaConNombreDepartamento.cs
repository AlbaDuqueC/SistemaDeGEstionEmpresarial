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
        public Persona Persona { get; set; }
        public string NombreDepartamento { get; set; }

        public List<Departamento> departamentos { get; set; }

        public PersonaConNombreDepartamento() { }

        public PersonaConNombreDepartamento(Persona persona, string nombreDepartamento, List<Departamento> departamentos)
        {
            Persona = persona;
            NombreDepartamento = nombreDepartamento;
            this.departamentos = departamentos;
        }
    }
}
