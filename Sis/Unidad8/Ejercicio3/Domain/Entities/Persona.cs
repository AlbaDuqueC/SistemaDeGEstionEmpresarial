
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("dbo.Personas")]
public class Persona
{
    #region ATRIBUTOS PRIVADOS
    private int _id;
    private string _nombre;
    private string _apellidos;
    private string _telefono;
    private string _direccion;
    private string _foto;
    private DateTime? _fechaNacimiento;
    private int? _idDepartamento;
    #endregion

    #region CONSTRUCTORES
    /// <summary>
    /// Constructor de la clase persona con todos sus atributos
    /// </summary>
    public Persona(int id, string nombre, string apellido, string telefono, string direccion, string foto, DateTime? fechaNacimiento, int? idDepartamento)
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
    public Persona()
    {
        this._id = 0;
        this._nombre = string.Empty;
        this._apellidos = string.Empty;
        this._foto = string.Empty;
        this._fechaNacimiento = null;
        this._direccion = string.Empty;
        this._telefono = string.Empty;
        this._idDepartamento = null;
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

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [Column("Nombre")]
    [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
    public string Nombre
    {
        get { return _nombre; }
        set { _nombre = value; }
    }

    [Required(ErrorMessage = "Los apellidos son obligatorios")]
    [Column("Apellidos")]
    [StringLength(150, ErrorMessage = "Los apellidos no pueden exceder los 150 caracteres")]
    public string Apellidos
    {
        get { return _apellidos; }
        set { _apellidos = value; }
    }

    [Column("Telefono")]
    [StringLength(20, ErrorMessage = "El teléfono no puede exceder los 20 caracteres")]
    [Phone(ErrorMessage = "El formato del teléfono no es válido")]
    public string Telefono
    {
        get { return _telefono; }
        set { _telefono = value; }
    }

    [Column("Direccion")]
    [StringLength(250, ErrorMessage = "La dirección no puede exceder los 250 caracteres")]
    public string Direccion
    {
        get { return _direccion; }
        set { _direccion = value; }
    }

    [Column("Foto")]
    [StringLength(500, ErrorMessage = "La ruta de la foto no puede exceder los 500 caracteres")]
    public string Foto
    {
        get { return _foto; }
        set { _foto = value; }
    }

    [Column("FechaNacimiento")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de Nacimiento")]
    public DateTime? FechaNacimiento
    {
        get { return _fechaNacimiento; }
        set { _fechaNacimiento = value; }
    }

    [Column("IDDepartamento")]
    [ForeignKey("Departamento")]
    public int? IdDepartamento
    {
        get { return _idDepartamento; }
        set { _idDepartamento = value; }
    }
    #endregion

    // Propiedad de navegación
    public virtual Departamento Departamento { get; set; }
}
}