/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the SectorEconomico type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the sector economico
	//// </summary>
	[Table("tblSectoresEconomicos")]
	public class SectorEconomico
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
		/// Gets or sets the string cod sector economico.
		/// </summary>
		/// <value>
		/// The string cod sector economico.
		/// </value>
		public string strCodSectorEconomico { get; set; }

		/// <summary>
		/// Gets or sets the string nombre sector economico.
		/// </summary>
		/// <value>
		/// The string nombre sector economico.
		/// </value>
		public string strNombreSectorEconomico { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}