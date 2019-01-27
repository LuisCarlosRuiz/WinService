/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoTransaccion type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Tipo Transaccion
	//// </summary>
	[Table("tblTiposTransaccion")]
	public class TipoTransaccion
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
		/// Gets or sets the string cod tipo transaccion.
		/// </summary>
		/// <value>
		/// The string cod tipo transaccion.
		/// </value>
		public string strCodTipoTransaccion { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo transaccion.
		/// </summary>
		/// <value>
		/// The string nombre tipo transaccion.
		/// </value>
		public string strNombreTipoTransaccion { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}