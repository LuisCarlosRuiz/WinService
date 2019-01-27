/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoIdentificacion type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the tipo identificacion
	//// </summary>
	[Table("tblTiposIdentificacion")]
	public class TipoIdentificacion
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
		/// Gets or sets the string cod tipo identificacion.
		/// </summary>
		/// <value>
		/// The string cod tipo identificacion.
		/// </value>
		public string strCodTipoIdentificacion { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo identificacion.
		/// </summary>
		/// <value>
		/// The string nombre tipo identificacion.
		/// </value>
		public string strNombreTipoIdentificacion { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
		
	}
}
