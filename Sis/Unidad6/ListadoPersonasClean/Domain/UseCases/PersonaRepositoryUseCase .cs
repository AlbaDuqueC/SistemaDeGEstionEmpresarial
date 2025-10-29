using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases
{
    public class DefaultGetListadoUseCase : IPersonaRepositoryUseCase
    {
        public List<Persona> getListaPersonas()
        {

            List<Persona> listaPersonaMayorDeEdad = new List<Persona>();

            //se inyecta la interfaz IPersonaRepository y se itera sobre el listado

            foreach (Persona persona in getListaPersonas())
            {
                if (persona.Edad >= 18)
                {
                    listaPersonaMayorDeEdad.Add(persona);
                }
            }

            //retorna la lista de las personas filtrada
            return listaPersonaMayorDeEdad;

        }
    }
}
