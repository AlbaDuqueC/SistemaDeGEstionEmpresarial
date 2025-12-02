using Data.DataBase;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data.Repositories.repositoriospersona
{
    public class PersonaRepositoryAzure : IPersonaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Persona> getListaPersonas()
        {
            List<Persona> lista = new();
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();
            string sql = "SELECT * FROM Personas";
            SqlCommand cmd = new(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                string apellidos = reader.GetString(2);

                string telefono = string.Empty;
                if (!reader.IsDBNull(3))
                    telefono = reader.GetString(3);

                string direccion = string.Empty;
                if (!reader.IsDBNull(4))
                    direccion = reader.GetString(4);

                string foto = string.Empty;
                if (!reader.IsDBNull(5))
                    foto = reader.GetString(5);

                DateTime fechaNacimiento = DateTime.MinValue;
                if (!reader.IsDBNull(6))
                    fechaNacimiento = reader.GetDateTime(6);

                int idDepartamento = reader.GetInt32(7);

                lista.Add(new Persona(id, nombre, apellidos, telefono, direccion, foto, fechaNacimiento, idDepartamento));
            }

            return lista;
        }

        public Persona getPersonaPorId(int id)
        {
            Persona persona = null;
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = "SELECT * FROM Personas WHERE Id=@id";
            SqlCommand cmd = new(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                persona = new Persona(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetDateTime(6),
                    reader.GetInt32(7)
                );
            }
            return persona;
        }


        public int actualizarPersona(int idPersona, Persona persona)
        {
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = @"UPDATE Personas SET 
            Nombre=@n, Apellidos=@a, Edad=@e, FechaNacimiento=@f, 
            Direccion=@d, Telefono=@t, IdDepartamento=@idD
            WHERE Id=@id";

            SqlCommand cmd = new(sql, conn);

            cmd.Parameters.AddWithValue("@id", idPersona);
            cmd.Parameters.AddWithValue("@n", persona.Nombre);
            cmd.Parameters.AddWithValue("@a", persona.Apellidos);
            cmd.Parameters.AddWithValue("@t", persona.Telefono);
            cmd.Parameters.AddWithValue("@d", persona.Direccion);
            cmd.Parameters.AddWithValue("@e", persona.Foto);
            cmd.Parameters.AddWithValue("@f", persona.FechaNacimiento);
            cmd.Parameters.AddWithValue("@idD", persona.IdDepartamento);

            return cmd.ExecuteNonQuery();
        }
        

        public int crearPersona(Persona personaNueva)
        {
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = @"INSERT INTO Personas 
            (Nombre, Apellidos, Edad, FechaNacimiento, Direccion, Telefono, IdDepartamento)
            VALUES (@n,@a,@e,@f,@d,@t,@idD)";

            SqlCommand cmd = new(sql, conn);


            cmd.Parameters.AddWithValue("@n", personaNueva.Nombre);
            cmd.Parameters.AddWithValue("@a", personaNueva.Apellidos);
            cmd.Parameters.AddWithValue("@t", personaNueva.Telefono);
            cmd.Parameters.AddWithValue("@d", personaNueva.Direccion);
            cmd.Parameters.AddWithValue("@e", personaNueva.Foto);
            cmd.Parameters.AddWithValue("@f", personaNueva.FechaNacimiento);
            cmd.Parameters.AddWithValue("@idD", personaNueva.IdDepartamento);

            return cmd.ExecuteNonQuery();
        }

        public int eliminarPersona(int idPersona)
        {
            using SqlConnection conn = new(BDConection.getConnectionString());
            conn.Open();

            string sql = "DELETE FROM Personas WHERE ID=@id";
            SqlCommand cmd = new(sql, conn);

            cmd.Parameters.AddWithValue("@id", idPersona);

            return cmd.ExecuteNonQuery();
        }

        
    }
}
