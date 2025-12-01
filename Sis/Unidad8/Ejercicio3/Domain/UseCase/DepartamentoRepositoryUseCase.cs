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
    public class DepartamentoRepositoryUseCase : IDepartamentoRepositoryUseCase
    {

        private IDepartamentoRepository _repositorioDepartamentos;

        public DepartamentoRepositoryUseCase(IDepartamentoRepository repo)
        {
            _repositorioDepartamentos = repo;
        }

        public List<Departamento> getListaDepartamento()
        { return _repositorioDepartamentos.getListaDepartamentos(); }

        public int crearDepartamento(Departamento departamentoNuevo)
        { return _repositorioDepartamentos.crearDepartamento(departamentoNuevo); }

        public int actualizarDepartamento(int idDepartamento, Departamento departamentoActualizado)
        { return _repositorioDepartamentos.actualizarDepartamento(idDepartamento, departamentoActualizado); }

        public int eliminarDepartamento(int idDepartamento)
        {
            if (_repositorioDepartamentos.contarDepartamento(idDepartamento) > 0)
                return -1; // No se puede eliminar
            
            return _repositorioDepartamentos.eliminarDepartamento(idDepartamento);
        }

    }
}
