/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoGarantia type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the tipo garantia
	//// </summary>
	[Table("tblTiposGarantias")]
	public class TipoGarantia
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod tipo garantia.
		/// </summary>
		/// <value>
		/// The string cod tipo garantia.
		/// </value>
		[Key]
		public string strCodTipoGarantia { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo garantia.
		/// </summary>
		/// <value>
		/// The string nombre tipo garantia.
		/// </value>
		public string strNombreTipoGarantia { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}