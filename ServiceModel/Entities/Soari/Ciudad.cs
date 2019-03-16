/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Ciudad type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Ciudad
	//// </summary>
	[Table("tblCiudades")]
	public class Ciudad
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod ciudad.
		/// </summary>
		/// <value>
		/// The string cod ciudad.
		/// </value>
		[Key]
		public string strCodCiudad { get; set; }

		/// <summary>
		/// Gets or sets the string nombre ciudad.
		/// </summary>
		/// <value>
		/// The string nombre ciudad.
		/// </value>
		public string strNombreCiudad { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}
