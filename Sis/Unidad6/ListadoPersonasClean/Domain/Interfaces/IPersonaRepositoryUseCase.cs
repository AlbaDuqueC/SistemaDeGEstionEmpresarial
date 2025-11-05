using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interfaz del caso de uso que permitirá a este pueda dejar
    /// al view model acceder a sus métodos el cuál consistirá en mandarle
    /// una lista
    /// </summary>
    public interface IPersonaRepositoryUseCase
    {
        public List<Persona> getListaPersonas();
    }
}
