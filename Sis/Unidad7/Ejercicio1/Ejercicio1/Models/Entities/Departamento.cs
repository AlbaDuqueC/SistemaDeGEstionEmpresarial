namespace Ejercicio1.Models.Entities
{
    public class Departamento
    {

        #region Atributos privados
        private int _idDep;
        private string _nombreDep;
        #endregion

        #region geters y setters
        public int id
        {
            get { return _idDep; }
            set { _idDep = value; }
        }

        public string nombre
        {
            get { return _nombreDep; }
            set { _nombreDep = value; }
        }
        #endregion

        #region constructores
        public Departamento(int id, string nombre)
        {
            this._idDep = id;
            this._nombreDep = nombre;

        }

        public Departamento()
        {
            this._idDep = 0;
            this._nombreDep = "";

        }


        #endregion

    }
}
