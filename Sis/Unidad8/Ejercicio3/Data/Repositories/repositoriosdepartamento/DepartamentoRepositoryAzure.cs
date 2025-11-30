using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.repositoriosdepartamento
{
    public class DepartamentoRepositoryAzure : IDepartamentoRepository
    {


        public List<Departamento> getListadoDepartamento()
        {
            List<Departamento> lista = new();
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = "SELECT * FROM Departamentos";
            SqlCommand cmd = new(sql, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Departamento(
                    reader.GetInt32(0),
                    reader.GetString(1)
                ));
            }

            return lista;
        }

        public int actualizarDepartamento(int id, Departamento departamento)
        {
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = @"UPDATE Departamentos SET Nombre=@n
                           WHERE Id=@id";

            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@n", departamento.Nombre);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery();
        }

        public int contarDepartamento(int id)
        {
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = "SELECT COUNT(*) FROM Personas WHERE IdDepartamento=@id";
            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return (int)cmd.ExecuteScalar();
        }

        public int crearDepartamento(Departamento departamentoNuevo)
        {
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = @"INSERT INTO Departamentos (Nombre)
                           VALUES (@n)";

            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@n", departamentoNuevo.Nombre);

            return cmd.ExecuteNonQuery();
        }

        public int eliminarDepartamento(int id)
        {
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = "DELETE FROM Departamentos WHERE Id=@id";

            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery();
        }

        public Departamento getDepartamentoPorId(int id)
        {
            Departamento dep = null;
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = "SELECT * FROM Departamentos WHERE Id=@id";
            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dep = new Departamento(
                    reader.GetInt32(0),
                    reader.GetString(1)
                );
            }
            return dep;
        }

        public List<Departamento> getListaDepartamentos()
        {
            throw new NotImplementedException();
        }
    }
}
