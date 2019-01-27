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

		/// <summary>
		/// Gets or sets the string codigo empresa trabajo.
		/// </summary>
		/// <value>
		/// The string codigo empresa trabajo.
		/// </value>
		public string strCodigoEmpresaTrabajo { get; set; }

		/// <summary>
		/// Gets or sets the string nombre empresa trabajo.
		/// </summary>
		/// <value>
		/// The string nombre empresa trabajo.
		/// </value>
		public string strNombreEmpresaTrabajo { get; set; }

		/// <summary>
		/// Gets or sets the identifier nivel estudio.
		/// </summary>
		/// <value>
		/// The identifier nivel estudio.
		/// </value>
		public int idNivelEstudio { get; set; }

		/// <summary>
		/// Gets or sets the number estrato.
		/// </summary>
		/// <value>
		/// The number estrato.
		/// </value>
		public int numEstrato { get; set; }

		/// <summary>
		/// Gets or sets the number nivel ingresos.
		/// </summary>
		/// <value>
		/// The number nivel ingresos.
		/// </value>
		public int numNivelIngresos { get; set; }

		/// <summary>
		/// Gets or sets the number salario.
		/// </summary>
		/// <value>
		/// The number salario.
		/// </value>
		public decimal numSalario { get; set; }

		/// <summary>
		/// Gets or sets the number total otros ingresos.
		/// </summary>
		/// <value>
		/// The number total otros ingresos.
		/// </value>
		public decimal numTotalOtrosIngresos { get; set; }

		/// <summary>
		/// Gets or sets the number total gastos.
		/// </summary>
		/// <value>
		/// The number total gastos.
		/// </value>
		public decimal numTotalGastos { get; set; }

		/// <summary>
		/// Gets or sets the identifier estado civil.
		/// </summary>
		/// <value>
		/// The identifier estado civil.
		/// </value>
		public int idEstadoCivil { get; set; }

		/// <summary>
		/// Gets or sets the identifier ocupacion.
		/// </summary>
		/// <value>
		/// The identifier ocupacion.
		/// </value>
		public int idOcupacion { get; set; }

		/// <summary>
		/// Gets or sets the identifier sector economico.
		/// </summary>
		/// <value>
		/// The identifier sector economico.
		/// </value>
		public int idSectorEconomico { get; set; }

		/// <summary>
		/// Gets or sets the identifier jornada laboral.
		/// </summary>
		/// <value>
		/// The identifier jornada laboral.
		/// </value>
		public int idJornadaLaboral { get; set; }

		/// <summary>
		/// Gets or sets the number personas cargo.
		/// </summary>
		/// <value>
		/// The number personas cargo.
		/// </value>
		public int numPersonasCargo { get; set; }

		/// <summary>
		/// Gets or sets the string pe ps.
		/// </summary>
		/// <value>
		/// The string pe ps.
		/// </value>
		public char strPEPs { get; set; }

		/// <summary>
		/// Gets or sets the string exonerado.
		/// </summary>
		/// <value>
		/// The string exonerado.
		/// </value>
		public char strExonerado { get; set; }

		/// <summary>
		/// Gets or sets the number score central riesgo.
		/// </summary>
		/// <value>
		/// The number score central riesgo.
		/// </value>
		public int numScoreCentralRiesgo { get; set; }

		/// <summary>
		/// Gets or sets the number segmento.
		/// </summary>
		/// <value>
		/// The number segmento.
		/// </value>
		public int numSegmento { get; set; }

		/// <summary>
		/// Gets or sets the string email.
		/// </summary>
		/// <value>
		/// The string email.
		/// </value>
		public string strEmail { get; set; }

		/// <summary>
		/// Gets or sets the string telefono.
		/// </summary>
		/// <value>
		/// The string telefono.
		/// </value>
		public string strTelefono { get; set; }

		/// <summary>
		/// Gets or sets the string direccion.
		/// </summary>
		/// <value>
		/// The string direccion.
		/// </value>
		public string strDireccion { get; set; }

		/// <summary>
		/// Gets or sets the tipo identificacion.
		/// </summary>
		/// <value>
		/// The tipo identificacion.
		/// </value>
		[ForeignKey("idTipoIdentificacion")]
		public TipoIdentificacion TipoIdentificacion { get; set; }

		/// <summary>
		/// Gets or sets the actividad economica.
		/// </summary>
		/// <value>
		/// The actividad economica.
		/// </value>
		[ForeignKey("idActividadEconomica")]
		public ActividadEconomica ActividadEconomica { get; set; }

		/// <summary>
		/// Gets or sets the agencia.
		/// </summary>
		/// <value>
		/// The agencia.
		/// </value>
		[ForeignKey("idAgencia")]
		public Agencia Agencia { get; set; }

		/// <summary>
		/// Gets or sets the pais.
		/// </summary>
		/// <value>
		/// The pais.
		/// </value>
		[ForeignKey("idPais")]
		public Pais Pais { get; set; }

		/// <summary>
		/// Gets or sets the departamento.
		/// </summary>
		/// <value>
		/// The departamento.
		/// </value>
		[ForeignKey("idDepartamento")]
		public Departamento Departamento { get; set; }

		/// <summary>
		/// Gets or sets the ciudad.
		/// </summary>
		/// <value>
		/// The ciudad.
		/// </value>
		[ForeignKey("idCiudad")]
		public Ciudad Ciudad { get; set; }

		/// <summary>
		/// Gets or sets the genero.
		/// </summary>
		/// <value>
		/// The genero.
		/// </value>
		[ForeignKey("idGenero")]
		public Genero Genero { get; set; }

		/// <summary>
		/// Gets or sets the tipo contrato.
		/// </summary>
		/// <value>
		/// The tipo contrato.
		/// </value>
		[ForeignKey("idTipoContrato")]
		public TipoContrato TipoContrato { get; set; }

		/// <summary>
		/// Gets or sets the nivel estudio.
		/// </summary>
		/// <value>
		/// The nivel estudio.
		/// </value>
		[ForeignKey("idNivelEstudio")]
		public NivelEstudio NivelEstudio { get; set; }

		/// <summary>
		/// Gets or sets the estado civil.
		/// </summary>
		/// <value>
		/// The estado civil.
		/// </value>
		[ForeignKey("idEstadoCivil")]
		public EstadoCivil EstadoCivil { get; set; }

		/// <summary>
		/// Gets or sets the ocupacion.
		/// </summary>
		/// <value>
		/// The ocupacion.
		/// </value>
		[ForeignKey("idOcupacion")]
		public Ocupacion Ocupacion { get; set; }

		/// <summary>
		/// Gets or sets the sector economico.
		/// </summary>
		/// <value>
		/// The sector economico.
		/// </value>
		[ForeignKey("idSectorEconomico")]
		public SectorEconomico SectorEconomico { get; set; }

		/// <summary>
		/// Gets or sets the jornada laboral.
		/// </summary>
		/// <value>
		/// The jornada laboral.
		/// </value>
		[ForeignKey("idJornadaLaboral")]
		public JornadaLaboral JornadaLaboral { get; set; }
	}
}
