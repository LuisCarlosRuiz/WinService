/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the NivelEstudio type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the nivel estudio
	//// </summary>
	[Table("tblNivelesEstudio")]
	public class NivelEstudio
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod nivel estudio.
		/// </summary>
		/// <value>
		/// The string cod nivel estudio.
		/// </value>
		[Key]
		public string strCodNivelEstudio { get; set; }

		/// <summary>
		/// Gets or sets the string nombre nivel estudio.
		/// </summary>
		/// <value>
		/// The string nombre nivel estudio.
		/// </value>
		public string strNombreNivelEstudio { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}