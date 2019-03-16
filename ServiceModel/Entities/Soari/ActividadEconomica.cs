/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the ActividadEconomica type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the actividad economica
	//// </summary>
	[Table("tblActividadEconomica")]
	public class ActividadEconomica
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod actividad economica.
		/// </summary>
		/// <value>
		/// The string cod actividad economica.
		/// </value>
		[Key]
		public string strCodActividadEconomica { get; set; }

		/// <summary>
		/// Gets or sets the string nombre actividad economica.
		/// </summary>
		/// <value>
		/// The string nombre actividad economica.
		/// </value>
		public string strNombreActividadEconomica { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}
