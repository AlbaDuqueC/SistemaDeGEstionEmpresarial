using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Departamento
    {

        #region ATRIBUTOS PRIVADOS

        private int _id;
        private string _nombre;

        #endregion

        #region CONSTRUCTORES
        /// <summary>
        /// Constructor de la clase departamento con todos sus atributos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        public Departamento(int id, String nombre)
        {
            this._id = id;
            this._nombre = nombre;

        }

        /// <summary>
        /// Constructor de la clase departamento vacío
        /// </summary>
        public Departamento()
        {
            this._id = 0;
            this._nombre = string.Empty;
        }

        #endregion

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

        #endregion

    }
}
