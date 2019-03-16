/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoModalidad type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Tipo Modalidad
	//// </summary>
	[Table("tblTiposModalidadCredito")]
	public class TipoModalidad
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod tipo modalidad credito.
		/// </summary>
		/// <value>
		/// The string cod tipo modalidad credito.
		/// </value>
		[Key]
		public string strCodTipoModalidadCredito { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo modalidad credito.
		/// </summary>
		/// <value>
		/// The string nombre tipo modalidad credito.
		/// </value>
		public string strNombreTipoModalidadCredito { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}