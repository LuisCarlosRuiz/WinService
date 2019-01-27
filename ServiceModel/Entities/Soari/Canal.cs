/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Canal type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Canal
	//// </summary>
	[Table("tblCanales")]
	public class Canal
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
		/// Gets or sets the string cod canal.
		/// </summary>
		/// <value>
		/// The string cod canal.
		/// </value>
		public string strCodCanal { get; set; }

		/// <summary>
		/// Gets or sets the string nombre canal.
		/// </summary>
		/// <value>
		/// The string nombre canal.
		/// </value>
		public string strNombreCanal { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}