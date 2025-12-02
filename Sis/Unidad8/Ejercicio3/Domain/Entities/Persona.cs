using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Persona
    {
        #region ATRIBUTOS PRIVADOS

        private int _id;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _direccion;
        private string _foto;
        private DateTime _fechaNacimiento;
        private int _idDepartamento;


        #endregion

        /// <summary>
        /// Constructor de la clase persona con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaNacimiento"></param>
        /// 
        public Persona(int id, string nombre, string apellido, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)

        {
            this._id = id;
            this._nombre = nombre;
            this._apellidos = apellido;
            this._telefono = telefono;
            this._direccion = direccion;
            this._fechaNacimiento = fechaNacimiento;
            this._foto = foto;
            this._idDepartamento = idDepartamento;
        }

        /// <summary>
        /// Constructor de la clase persona vacío
        /// </summary>
        public Persona() { 
            
            this._id = 0;
            this._nombre = string.Empty;
            this._apellidos = string.Empty;
            this._foto = string.Empty;
            this._fechaNacimiento = DateTime.MinValue;
            this._direccion = string.Empty;
            this._telefono = string.Empty;
            this._idDepartamento = 0;

        }

        #region GETTERS Y SETTERS

        public int ID
        {
            get
            {
                return _id;
            }
           
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
            }
        }

        public string Apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
            }
        }

        public string Foto
        {
            get
            {
                return _foto;
            }
            set
            {
                _foto = value;
            }
        }

        public DateTime FechaNacimiento
        {
            get
            {
                return _fechaNacimiento;
            }
            set
            {
                _fechaNacimiento = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
            }
        }

        public int IdDepartamento
        {
            get
            {
                return _idDepartamento;
            }
            set
            {
                _idDepartamento = value;
            }
        }

        

        #endregion
    }
}