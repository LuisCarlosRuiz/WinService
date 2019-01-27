/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Ocupacion type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Ocupacion
	//// </summary>
	[Table("tblOcupaciones")]
	public class Ocupacion
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
		/// Gets or sets the string cod ocupacion.
		/// </summary>
		/// <value>
		/// The string cod ocupacion.
		/// </value>
		public string strCodOcupacion { get; set; }

		/// <summary>
		/// Gets or sets the string nombre ocupacion.
		/// </summary>
		/// <value>
		/// The string nombre ocupacion.
		/// </value>
		public string strNombreOcupacion { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}