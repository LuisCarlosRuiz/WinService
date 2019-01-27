/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Agencia type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Agencia
	//// </summary>
	[Table("tblAgencias")]
	public class Agencia
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
		/// Gets or sets the string cod agencia.
		/// </summary>
		/// <value>
		/// The string cod agencia.
		/// </value>
		public string strCodAgencia { get; set; }

		/// <summary>
		/// Gets or sets the string nombre agencia.
		/// </summary>
		/// <value>
		/// The string nombre agencia.
		/// </value>
		public string strNombreAgencia { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}
