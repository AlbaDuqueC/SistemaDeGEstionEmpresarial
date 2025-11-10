using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Mision
    {

        private int _id;
        private String _nombre;
        private String _descripcion;
        private int _recompensa;


        public Mision(int id, String nombre, String descripcion, int recompensa)
        {
            _id = id;
            _nombre = nombre;
            _descripcion = descripcion;
            _recompensa = recompensa;
        }
        public Mision()
        {

        }

        public int Id
        {
            get
            {
                return _id;
            }

        }

        public String Nombre
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
        public String Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
            }
        }
        public int Recompensa
        {
            get
            {
                return _recompensa;
            }
            set
            {
                _recompensa = value;
            }

        }
    }
}
