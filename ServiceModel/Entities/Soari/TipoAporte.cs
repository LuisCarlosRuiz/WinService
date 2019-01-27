/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoAporte type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Tipo Aporte
	//// </summary>
	[Table("tblTiposAportes")]
	public class TipoAporte
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
		/// Gets or sets the string cod tipo aporte.
		/// </summary>
		/// <value>
		/// The string cod tipo aporte.
		/// </value>
		public string strCodTipoAporte { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo aporte.
		/// </summary>
		/// <value>
		/// The string nombre tipo aporte.
		/// </value>
		public string strNombreTipoAporte { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}