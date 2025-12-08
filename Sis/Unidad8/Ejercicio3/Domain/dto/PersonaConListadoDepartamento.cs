using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.dto
{
    public class PersonaConListadoDepartamento
    {
        private List<Departamento> departamentos;

        public Persona Persona { get; private set; }
        public List<Departamento> ListadoDepartamento { get; private set; }

        public PersonaConListadoDepartamento(Persona persona, IDepartamentoRepository repoDepartamentos)
        {
            Persona = persona;
            ListadoDepartamento = repoDepartamentos.getListaDepartamentos();
        }

        public PersonaConListadoDepartamento(Persona persona, List<Departamento> departamentos)
        {
            Persona = persona;
            this.departamentos = departamentos;
        }
    }
}
