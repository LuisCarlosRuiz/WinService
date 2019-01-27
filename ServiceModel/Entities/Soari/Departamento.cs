/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Departamento type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Departamento
	//// </summary>
	[Table("tblDepartamentos")]
	public class Departamento
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
		/// Gets or sets the string cod departamento.
		/// </summary>
		/// <value>
		/// The string cod departamento.
		/// </value>
		public string strCodDepartamento { get; set; }

		/// <summary>
		/// Gets or sets the string nombre departamento.
		/// </summary>
		/// <value>
		/// The string nombre departamento.
		/// </value>
		public string strNombreDepartamento { get; set; }

		/// <summary>
		/// Gets or sets the int identifier pais.
		/// </summary>
		/// <value>
		/// The int identifier pais.
		/// </value>
		public int intIdPais { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}
