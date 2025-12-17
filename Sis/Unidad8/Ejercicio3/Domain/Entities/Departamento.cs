using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("dbo.Departamentos")]
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

        #region PROPIEDADES CON DATA ANNOTATIONS
        [Key]
        [Column("ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        [Required(ErrorMessage = "El nombre del departamento es obligatorio")]
        [Column("Nombre")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        #endregion

        // Propiedad de navegación
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
