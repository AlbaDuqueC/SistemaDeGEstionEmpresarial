using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IDepartamentoRepository
    {

        public List<Departamento> getListaDepartamentos();

        public Departamento getDepartamentoPorId(int id);

        public int crearDepartamento(Departamento departamentoNuevo);

        public int actualizarDepartamento(int id, Departamento departamento);

        public int eliminarDepartamento(int id);

        public int contarDepartamento(int id);

    }
}
