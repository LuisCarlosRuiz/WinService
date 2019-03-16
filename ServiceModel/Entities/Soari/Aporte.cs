/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Aporte type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Aporte
	//// </summary>
	[Table("tblAportes")]
	public class Aporte
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
		/// Gets or sets the number nit.
		/// </summary>
		/// <value>
		/// The number nit.
		/// </value>
		public long numNit { get; set; }

		/// <summary>
		/// Gets or sets the identifier tipo aporte.
		/// </summary>
		/// <value>
		/// The identifier tipo aporte.
		/// </value>
		public int idTipoAporte { get; set; }

		/// <summary>
		/// Gets or sets the identifier agencia.
		/// </summary>
		/// <value>
		/// The identifier agencia.
		/// </value>
		public int idAgencia { get; set; }

		/// <summary>
		/// Gets or sets the string linea.
		/// </summary>
		/// <value>
		/// The string linea.
		/// </value>
		public string strLinea { get; set; }

		/// <summary>
		/// Gets or sets the string numero cuenta.
		/// </summary>
		/// <value>
		/// The string numero cuenta.
		/// </value>
		public string strNumeroCuenta { get; set; }

		/// <summary>
		/// Gets or sets the number valor revalorizacion.
		/// </summary>
		/// <value>
		/// The number valor revalorizacion.
		/// </value>
		public decimal numValorRevalorizacion { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha revalorizacion.
		/// </summary>
		/// <value>
		/// The DTM fecha revalorizacion.
		/// </value>
		public DateTime dtmFechaRevalorizacion { get; set; }

		/// <summary>
		/// Gets or sets the number cuota mensual.
		/// </summary>
		/// <value>
		/// The number cuota mensual.
		/// </value>
		public decimal numCuotaMensual { get; set; }

		/// <summary>
		/// Gets or sets the number saldo aporte.
		/// </summary>
		/// <value>
		/// The number saldo aporte.
		/// </value>
		public decimal numSaldoAporte { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha apertura.
		/// </summary>
		/// <value>
		/// The DTM fecha apertura.
		/// </value>
		public DateTime dtmFechaApertura { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha cancelacion.
		/// </summary>
		/// <value>
		/// The DTM fecha cancelacion.
		/// </value>
		public DateTime dtmFechaCancelacion { get; set; }

		/// <summary>
		/// Gets or sets the number estado.
		/// </summary>
		/// <value>
		/// The number estado.
		/// </value>
		public int numEstado { get; set; }

		/// <summary>
		/// Gets or sets the number cuota ahorro.
		/// </summary>
		/// <value>
		/// The number cuota ahorro.
		/// </value>
		public decimal numCuotaAhorro { get; set; }
	}
}
