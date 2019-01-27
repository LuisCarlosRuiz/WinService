/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Pais type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the pais
	//// </summary>
	[Table("tblPaises")]
	public class Pais
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
		/// Gets or sets the string cod pais.
		/// </summary>
		/// <value>
		/// The string cod pais.
		/// </value>
		public string strCodPais { get; set; }

		/// <summary>
		/// Gets or sets the string nombre pais.
		/// </summary>
		/// <value>
		/// The string nombre pais.
		/// </value>
		public string strNombrePais { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}
