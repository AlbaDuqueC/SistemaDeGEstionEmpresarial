namespace Ejercicio1.Models.Entities
{
    public class Persona
    {
        #region Atributos privados
        private int _id;
        private string _nombre;
        private int _edad;
        #endregion
        #region geters y setters
        
        public int id {             
            get { return _id; }
            set { _id = value; }
        }

        public string nombre {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public int edad {
            get { return _edad; }
            set { _edad = value; }
        }



        #endregion

        #region constructores
        public Persona(int id, string nombre, int edad)
        {
            this._id = id;
            this._nombre = nombre;
            this._edad = edad;
        }

        public Persona()
        {
            this._id = 0;
            this._nombre = "";
            this._edad = 0;
        }


        #endregion


    }

}
