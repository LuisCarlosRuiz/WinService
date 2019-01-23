/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the nits type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the nits
	//// </summary>
	[Table("tblnits")]
	public class Nit
	{
		//// <summary>
		//// Gets or sets the number nit.
		//// </summary>
		//// <value>
		//// The number nit.
		//// </value>
		[Key]
		public long numNit { get; set; }

		/// <summary>
		/// Gets or sets the identifier tipo identificacion.
		/// </summary>
		/// <value>
		/// The identifier tipo identificacion.
		/// </value>
		public int idTipoIdentificacion { get; set; }

		/// <summary>
		/// Gets or sets the string nombre integrado.
		/// </summary>
		/// <value>
		/// The string nombre integrado.
		/// </value>
		public string strNombreIntegrado { get; set; }

		/// <summary>
		/// Gets or sets the string primer nombre.
		/// </summary>
		/// <value>
		/// The string primer nombre.
		/// </value>
		public string strPrimerNombre { get; set; }

		/// <summary>
		/// Gets or sets the string segundo nombre.
		/// </summary>
		/// <value>
		/// The string segundo nombre.
		/// </value>
		public string strSegundoNombre { get; set; }

		/// <summary>
		/// Gets or sets the string primer apellido.
		/// </summary>
		/// <value>
		/// The string primer apellido.
		/// </value>
		public string strPrimerApellido { get; set; }

		/// <summary>
		/// Gets or sets the string segundo apellido.
		/// </summary>
		/// <value>
		/// The string segundo apellido.
		/// </value>
		public string strSegundoApellido { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha nacimiento.
		/// </summary>
		/// <value>
		/// The DTM fecha nacimiento.
		/// </value>
		public DateTime dtmFechaNacimiento { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha ingreso.
		/// </summary>
		/// <value>
		/// The DTM fecha ingreso.
		/// </value>
		public DateTime dtmFechaIngreso { get; set; }

		/// <summary>
		/// Gets or sets the identifier actividad economica.
		/// </summary>
		/// <value>
		/// The identifier actividad economica.
		/// </value>
		public int idActividadEconomica { get; set; }

		/// <summary>
		/// Gets or sets the identifier agencia.
		/// </summary>
		/// <value>
		/// The identifier agencia.
		/// </value>
		public int idAgencia { get; set; }

		/// <summary>
		/// Gets or sets the identifier pais.
		/// </summary>
		/// <value>
		/// The identifier pais.
		/// </value>
		public int idPais { get; set; }

		/// <summary>
		/// Gets or sets the identifier departamento.
		/// </summary>
		/// <value>
		/// The identifier departamento.
		/// </value>
		public int idDepartamento { get; set; }

		/// <summary>
		/// Gets or sets the identifier ciudad.
		/// </summary>
		/// <value>
		/// The identifier ciudad.
		/// </value>
		public int idCiudad { get; set; }

		/// <summary>
		/// Gets or sets the string zona.
		/// </summary>
		/// <value>
		/// The string zona.
		/// </value>
		public string strZona { get; set; }

		/// <summary>
		/// Gets or sets the string barrio.
		/// </summary>
		/// <value>
		/// The string barrio.
		/// </value>
		public string strBarrio { get; set; }

		/// <summary>
		/// Gets or sets the identifier genero.
		/// </summary>
		/// <value>
		/// The identifier genero.
		/// </value>
		public int idGenero { get; set; }

		/// <summary>
		/// Gets or sets the string empleado.
		/// </summary>
		/// <value>
		/// The string empleado.
		/// </value>
		public char strEmpleado { get; set; }

		/// <summary>
		/// Gets or sets the identifier tipo contrato.
		/// </summary>
		/// <value>
		/// The identifier tipo contrato.
		/// </value>
		public int idTipoContrato { get; set; }
	}
}
