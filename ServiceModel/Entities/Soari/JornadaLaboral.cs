/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the JornadaLaboral type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the jornada laboral
	//// </summary>
	[Table("tblJornadasLaborales")]
	public class JornadaLaboral
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		[Key]
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod jornada laboral.
		/// </summary>
		/// <value>
		/// The string cod jornada laboral.
		/// </value>
		public string strCodJornadaLaboral { get; set; }

		/// <summary>
		/// Gets or sets the string nombre jornada laboral.
		/// </summary>
		/// <value>
		/// The string nombre jornada laboral.
		/// </value>
		public string strNombreJornadaLaboral { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}