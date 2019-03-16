/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the EstadoCivil type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Estado Civil
	//// </summary>
	[Table("tblEstadosCiviles")]
	public class EstadoCivil
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod estado civil.
		/// </summary>
		/// <value>
		/// The string cod estado civil.
		/// </value>
		[Key]
		public string strCodEstadoCivil { get; set; }

		/// <summary>
		/// Gets or sets the string nombre estado civil.
		/// </summary>
		/// <value>
		/// The string nombre estado civil.
		/// </value>
		public string strNombreEstadoCivil { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}