using System;
using System.ComponentModel.DataAnnotations;



namespace Domain.Entities 
{ 
	/// <summary>
	/// Represents a person with an identifier, name, surname, and birth date.
	/// </summary>
	/// <remarks>The <see cref="Persona"/> class provides properties to store and retrieve personal information such
	/// as the unique identifier, first name, last name, and date of birth. It offers constructors to initialize these
	/// properties with default or specified values.</remarks>
	public class Persona
	{
		#region Atributos

		/// <summary>
		/// Gets the unique identifier for the entity.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the name associated with the entity.
		/// </summary>
		public string Nombre { get; set; }

		/// <summary>
		/// Gets or sets the last name of the individual.
		/// </summary>
		public string Apellido { get; set; }

		/// <summary>
		/// Gets or sets the date of birth.
		/// </summary>
		public DateTime FechaNacimiento { get; set; }

		public string Direccion { get; set; }

		public string Telefono { get; set; }
        #endregion

        #region Constructores

        /// <summary>
        /// Initializes a new instance of the <see cref="Persona"/> class with default values.
        /// </summary>
        /// <remarks>The default constructor sets the <see cref="Id"/> to 0, <see cref="Nombre"/> and <see
        /// cref="Apellido"/> to empty strings, and <see cref="FechaNacimiento"/> to null.</remarks>
        public Persona()
		{
			Id = 0;
			Nombre = string.Empty;
			Apellido = string.Empty;
			FechaNacimiento = DateTime.MinValue;
			Telefono = string.Empty;
			Direccion = string.Empty;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Persona"/> class with the specified details.
		/// </summary>
		/// <param name="id">The unique identifier for the persona.</param>
		/// <param name="nombre">The first name of the persona. Cannot be null or empty.</param>
		/// <param name="apellido">The last name of the persona. Cannot be null or empty.</param>
		/// <param name="fechaNacimiento">The birth date of the persona.</param>
		public Persona(int id, string nombre, string apellido, DateTime fechaNacimiento, String direccion, String telefono)
			{
			Id = id;
			Nombre = nombre;
			Apellido = apellido;
			FechaNacimiento = fechaNacimiento;
			Direccion = direccion;
			Telefono = telefono;
        }
		#endregion
	}
}
