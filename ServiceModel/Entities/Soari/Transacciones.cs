/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Transacciones type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Transacciones
	//// </summary>
	[Table("tblTransacciones")]
	public class Transacciones
	{
		/// <summary>
		/// Gets or sets the identifier registro.
		/// </summary>
		/// <value>
		/// The identifier registro.
		/// </value>
		[Key]
		public int idRegistro { get; set; }

		/// <summary>
		/// Gets or sets the number año.
		/// </summary>
		/// <value>
		/// The number año.
		/// </value>
		public int numAño { get; set; }

		/// <summary>
		/// Gets or sets the number periodo.
		/// </summary>
		/// <value>
		/// The number periodo.
		/// </value>
		public int numPeriodo { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha hora.
		/// </summary>
		/// <value>
		/// The DTM fecha hora.
		/// </value>
		public DateTime dtmFechaHora { get; set; }

		/// <summary>
		/// Gets or sets the number nit.
		/// </summary>
		/// <value>
		/// The number nit.
		/// </value>
		public long numNit { get; set; }

		/// <summary>
		/// Gets or sets the identifier tipo producto.
		/// </summary>
		/// <value>
		/// The identifier tipo producto.
		/// </value>
		public int idTipoProducto { get; set; }

		/// <summary>
		/// Gets or sets the string linea producto.
		/// </summary>
		/// <value>
		/// The string linea producto.
		/// </value>
		public string strLineaProducto { get; set; }

		/// <summary>
		/// Gets or sets the string numero cuenta.
		/// </summary>
		/// <value>
		/// The string numero cuenta.
		/// </value>
		public string strNumeroCuenta { get; set; }

		/// <summary>
		/// Gets or sets the identifier tipo transaccion.
		/// </summary>
		/// <value>
		/// The identifier tipo transaccion.
		/// </value>
		public int idTipoTransaccion { get; set; }

		/// <summary>
		/// Gets or sets the string numero recibo.
		/// </summary>
		/// <value>
		/// The string numero recibo.
		/// </value>
		public string strNumeroRecibo { get; set; }

		/// <summary>
		/// Gets or sets the number valor efectivo.
		/// </summary>
		/// <value>
		/// The number valor efectivo.
		/// </value>
		public decimal numValorEfectivo { get; set; }

		/// <summary>
		/// Gets or sets the number valor cheque.
		/// </summary>
		/// <value>
		/// The number valor cheque.
		/// </value>
		public decimal numValorCheque { get; set; }

		/// <summary>
		/// Gets or sets the identifier canal.
		/// </summary>
		/// <value>
		/// The identifier canal.
		/// </value>
		public int idCanal { get; set; }

		/// <summary>
		/// Gets or sets the string lugar transaccion.
		/// </summary>
		/// <value>
		/// The string lugar transaccion.
		/// </value>
		public string strLugarTransaccion { get; set; }

		/// <summary>
		/// Gets or sets the string operador transaccion.
		/// </summary>
		/// <value>
		/// The string operador transaccion.
		/// </value>
		public string strOperadorTransaccion { get; set; }

		/// <summary>
		/// Gets or sets the identifier agencia.
		/// </summary>
		/// <value>
		/// The identifier agencia.
		/// </value>
		public int idAgencia { get; set; }
	}
}
