using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Persona
    {
        // Atributos privados
        private int _id;
        private string _nombre;
        private string _apellidos;

        // Constructor
        public Persona(int id, string nombre, string apellidos)
        {
            _id = id;
            _nombre = nombre;
            _apellidos = apellidos;
        }

        // Propiedad Id (solo lectura)
        public int Id
        {
            get { return _id; }
        }

        // Propiedad Nombre (lectura/escritura)
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        // Propiedad Apellidos (lectura/escritura)
        public string Apellidos
        {
            get { return _apellidos; }
            set { _apellidos = value; }
        }
    }

}
