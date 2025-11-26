using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Departamento
    {

        private int _id;
        private string _nombre;

        public Departamento(int id, String nombre)
        {
            this._id = id;
            this._nombre = nombre;

        }

        public Departamento()
        {
            this._id = 0;
            this._nombre = string.Empty;
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

        #endregion

    }
}
