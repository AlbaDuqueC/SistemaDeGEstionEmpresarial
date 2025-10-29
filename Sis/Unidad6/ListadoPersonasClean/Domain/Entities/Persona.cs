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
        private string _apellido;
        private int _edad;

        #endregion

        /// <summary>
        /// Constructor de la clase persona con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        public Persona(int id, string nombre, string apellido, int edad)
        {
            this._id = id;
            this._nombre = nombre;
            this._apellido = apellido;
            this._edad = edad;
        }

        /// <summary>
        /// Constructor de la clase persona vacío
        /// </summary>
        public Persona() { }

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

        public string Apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;
            }
        }

        public int Edad
        {
            get
            {
                return _edad;
            }
            set
            {
                _edad = value;
            }
        }

        #endregion
    }
}