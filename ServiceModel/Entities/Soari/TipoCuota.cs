/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the TipoCuota type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Tipo Cuota
	//// </summary>
	[Table("tblTiposCuotaCredito")]
	public class TipoCuota
	{
		/// <summary>
		/// Gets or sets the int identifier.
		/// </summary>
		/// <value>
		/// The int identifier.
		/// </value>
		public int intId { get; set; }

		/// <summary>
		/// Gets or sets the string cod tipo cuota credito.
		/// </summary>
		/// <value>
		/// The string cod tipo cuota credito.
		/// </value>
		[Key]
		public string strCodTipoCuotaCredito { get; set; }

		/// <summary>
		/// Gets or sets the string nombre tipo cuota credito.
		/// </summary>
		/// <value>
		/// The string nombre tipo cuota credito.
		/// </value>
		public string strNombreTipoCuotaCredito { get; set; }

		/// <summary>
		/// Gets or sets the string equivalencia opa.
		/// </summary>
		/// <value>
		/// The string equivalencia opa.
		/// </value>
		public string strEquivalenciaOPA { get; set; }
	}
}