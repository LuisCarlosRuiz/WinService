/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoContrato type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the tipo contrato
	//// </summary>
	[Table("tblTiposContrato")]
	public class TipoContrato
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
		/// Gets or sets the string cod tipo contrato.
		/// </summary>
		/// <value>
		/// The string cod tipo contrato.
		/// </value>
		public string strCodTipoContrato { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo contrato.
		/// </summary>
		/// <value>
		/// The string nombre tipo contrato.
		/// </value>
		public string strNombreTipoContrato { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}
