/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Ahorro type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Ahorro
	//// </summary>
	[Table("tblAhorros")] 
	public class Ahorro
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
		/// Gets or sets the identifier tipo ahorro.
		/// </summary>
		/// <value>
		/// The identifier tipo ahorro.
		/// </value>
		public int idTipoAhorro { get; set; }

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
		/// Gets or sets the string cuenta.
		/// </summary>
		/// <value>
		/// The string cuenta.
		/// </value>
		public string strCuenta { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha apertura.
		/// </summary>
		/// <value>
		/// The DTM fecha apertura.
		/// </value>
		public DateTime dtmFechaApertura { get; set; }

		/// <summary>
		/// Gets or sets the number periodo pago interes.
		/// </summary>
		/// <value>
		/// The number periodo pago interes.
		/// </value>
		public int numPeriodoPagoInteres { get; set; }

		/// <summary>
		/// Gets or sets the number plazo.
		/// </summary>
		/// <value>
		/// The number plazo.
		/// </value>
		public int numPlazo { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha vencimiento.
		/// </summary>
		/// <value>
		/// The DTM fecha vencimiento.
		/// </value>
		public DateTime dtmFechaVencimiento { get; set; }

		/// <summary>
		/// Gets or sets the number tasa efectiva.
		/// </summary>
		/// <value>
		/// The number tasa efectiva.
		/// </value>
		public decimal numTasaEfectiva { get; set; }

		/// <summary>
		/// Gets or sets the number tasa nominal periodica.
		/// </summary>
		/// <value>
		/// The number tasa nominal periodica.
		/// </value>
		public decimal numTasaNominalPeriodica { get; set; }

		/// <summary>
		/// Gets or sets the number intereses causados.
		/// </summary>
		/// <value>
		/// The number intereses causados.
		/// </value>
		public decimal numInteresesCausados { get; set; }

		/// <summary>
		/// Gets or sets the number interes disponible.
		/// </summary>
		/// <value>
		/// The number interes disponible.
		/// </value>
		public decimal numInteresDisponible { get; set; }

		/// <summary>
		/// Gets or sets the number saldo ahorro.
		/// </summary>
		/// <value>
		/// The number saldo ahorro.
		/// </value>
		public decimal numSaldoAhorro { get; set; }

		/// <summary>
		/// Gets or sets the identifier estado ahorro.
		/// </summary>
		/// <value>
		/// The identifier estado ahorro.
		/// </value>
		public int idEstadoAhorro { get; set; }

		/// <summary>
		/// Gets or sets the tipo ahorro.
		/// </summary>
		/// <value>
		/// The tipo ahorro.
		/// </value>
		[ForeignKey("idTipoAhorro")]
		public TipoAhorro TipoAhorro { get; set; }

		/// <summary>
		/// Gets or sets my property.
		/// </summary>
		/// <value>
		/// My property.
		/// </value>
		[ForeignKey("idAgencia")]
		public Agencia Agencia { get; set; }

		/// <summary>
		/// Gets or sets the estado ahorro.
		/// </summary>
		/// <value>
		/// The estado ahorro.
		/// </value>
		[ForeignKey("idEstadoAhorro")]
		public EstadoAhorro EstadoAhorro { get; set; }
	}
}
