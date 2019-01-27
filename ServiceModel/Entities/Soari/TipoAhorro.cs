/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoAhorro type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Tipo Ahorro
	//// </summary>
	[Table("tblTiposAhorro")]
	public class TipoAhorro
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
		/// Gets or sets the string cod tipo ahorro.
		/// </summary>
		/// <value>
		/// The string cod tipo ahorro.
		/// </value>
		public string strCodTipoAhorro { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo ahorro.
		/// </summary>
		/// <value>
		/// The string nombre tipo ahorro.
		/// </value>
		public string strNombreTipoAhorro { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}