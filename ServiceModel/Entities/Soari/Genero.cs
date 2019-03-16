/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Genero type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Genero
	//// </summary>
	[Table("tblGeneros")]
	public class Genero
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod genero.
		/// </summary>
		/// <value>
		/// The string cod genero.
		/// </value>
		[Key]
		public string strCodGenero { get; set; }

		/// <summary>
		/// Gets or sets the string nombre genero.
		/// </summary>
		/// <value>
		/// The string nombre genero.
		/// </value>
		public string strNombreGenero { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}
