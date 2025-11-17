using Domain.Entities;
using Domain.RepositoriesInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataBase;

namespace Data.Repositories
{
    public class PersonaRepositoryAzure : IPersonaRepository
    {
        public List<Persona> GetListadoPersonas()
        {
            SqlConnection miConexion = new SqlConnection();
            List<Persona> listadoPersonas = new List<Persona>();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            Persona oPersona;

            miConexion.ConnectionString = Conection.GetConnectionString();

            try
            {
                miConexion.Open();

                miComando.CommandText = "SELECT * FROM personas";
                miComando.Connection = miConexion;

                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        oPersona = new Persona();

                        oPersona.Id = (int)miLector["ID"];
                        oPersona.Nombre = (string)miLector["Nombre"];
                        oPersona.Apellido = (string)miLector["Apellidos"];

                        if (miLector["FechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                        }

                        oPersona.Direccion = (string)miLector["Direccion"];
                        oPersona.Telefono = (string)miLector["Telefono"];

                        listadoPersonas.Add(oPersona);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException exSql)
            {
                throw exSql;
            }

            return listadoPersonas;
        }
    }
}
