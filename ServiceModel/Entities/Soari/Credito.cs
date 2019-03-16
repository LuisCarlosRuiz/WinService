/// --------------------------------------------------------------------------------------------------------------------
/// Luis Carlos Ruiz 
/// <summary>
///   Defines the Credito type.
/// </summary>
/// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Soari
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	//// <summary>
	//// the Credito
	//// </summary>
	[Table("tblCreditos")]
	public class Credito
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
		/// Gets or sets the string linea.
		/// </summary>
		/// <value>
		/// The string linea.
		/// </value>
		public string strLinea { get; set; }

		/// <summary>
		/// Gets or sets the string destino.
		/// </summary>
		/// <value>
		/// The string destino.
		/// </value>
		public string strDestino { get; set; }

		/// <summary>
		/// Gets or sets the string pagare.
		/// </summary>
		/// <value>
		/// The string pagare.
		/// </value>
		public string strPagare { get; set; }

		/// <summary>
		/// Gets or sets the identifier agencia.
		/// </summary>
		/// <value>
		/// The identifier agencia.
		/// </value>
		public int idAgencia { get; set; }

		/// <summary>
		/// Gets or sets the string categoria.
		/// </summary>
		/// <value>
		/// The string categoria.
		/// </value>
		public string strCategoria { get; set; }

		/// <summary>
		/// Gets or sets the string categoria final.
		/// </summary>
		/// <value>
		/// The string categoria final.
		/// </value>
		public string strCategoriaFinal { get; set; }

		/// <summary>
		/// Gets or sets the number dias mora.
		/// </summary>
		/// <value>
		/// The number dias mora.
		/// </value>
		public int numDiasMora { get; set; }

		/// <summary>
		/// Gets or sets the number provision capital.
		/// </summary>
		/// <value>
		/// The number provision capital.
		/// </value>
		public decimal numProvisionCapital { get; set; }

		/// <summary>
		/// Gets or sets the number provision interes.
		/// </summary>
		/// <value>
		/// The number provision interes.
		/// </value>
		public decimal numProvisionInteres { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha desembolso.
		/// </summary>
		/// <value>
		/// The DTM fecha desembolso.
		/// </value>
		public DateTime dtmFechaDesembolso { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha vencimiento.
		/// </summary>
		/// <value>
		/// The DTM fecha vencimiento.
		/// </value>
		public DateTime dtmFechaVencimiento { get; set; }

		/// <summary>
		/// Gets or sets the identifier tipo garantia.
		/// </summary>
		/// <value>
		/// The identifier tipo garantia.
		/// </value>
		public int idTipoGarantia { get; set; }

		/// <summary>
		/// Gets or sets the number valor garantia.
		/// </summary>
		/// <value>
		/// The number valor garantia.
		/// </value>
		public decimal numValorGarantia { get; set; }

		/// <summary>
		/// Gets or sets the identifier tipo cuota credito.
		/// </summary>
		/// <value>
		/// The identifier tipo cuota credito.
		/// </value>
		public int idTipoCuotaCredito { get; set; }

		/// <summary>
		/// Gets or sets the identifier tipo modalidad credito.
		/// </summary>
		/// <value>
		/// The identifier tipo modalidad credito.
		/// </value>
		public int idTipoModalidadCredito { get; set; }

		/// <summary>
		/// Gets or sets the number monto inicial.
		/// </summary>
		/// <value>
		/// The number monto inicial.
		/// </value>
		public decimal numMontoInicial { get; set; }

		/// <summary>
		/// Gets or sets the number anualidad.
		/// </summary>
		/// <value>
		/// The number anualidad.
		/// </value>
		public decimal numAnualidad { get; set; }

		/// <summary>
		/// Gets or sets the number interes corriente.
		/// </summary>
		/// <value>
		/// The number interes corriente.
		/// </value>
		public decimal numInteresCorriente { get; set; }

		/// <summary>
		/// Gets or sets the number interes mora.
		/// </summary>
		/// <value>
		/// The number interes mora.
		/// </value>
		public decimal numInteresMora { get; set; }

		/// <summary>
		/// Gets or sets the number interes corriente contingente.
		/// </summary>
		/// <value>
		/// The number interes corriente contingente.
		/// </value>
		public decimal numInteresCorrienteContingente { get; set; }

		/// <summary>
		/// Gets or sets the number interes mora contingente.
		/// </summary>
		/// <value>
		/// The number interes mora contingente.
		/// </value>
		public decimal numInteresMoraContingente { get; set; }

		/// <summary>
		/// Gets or sets the number saldo al dia.
		/// </summary>
		/// <value>
		/// The number saldo al dia.
		/// </value>
		public decimal numSaldoAlDia { get; set; }

		/// <summary>
		/// Gets or sets the number saldo capital.
		/// </summary>
		/// <value>
		/// The number saldo capital.
		/// </value>
		public decimal numSaldoCapital { get; set; }

		/// <summary>
		/// Gets or sets the number periodicidad.
		/// </summary>
		/// <value>
		/// The number periodicidad.
		/// </value>
		public int numPeriodicidad { get; set; }

		/// <summary>
		/// Gets or sets the number plazo.
		/// </summary>
		/// <value>
		/// The number plazo.
		/// </value>
		public int numPlazo { get; set; }

		/// <summary>
		/// Gets or sets the DTM fecha proximo pago.
		/// </summary>
		/// <value>
		/// The DTM fecha proximo pago.
		/// </value>
		public DateTime dtmFechaProximoPago { get; set; }

		/// <summary>
		/// Gets or sets the number altura cuota.
		/// </summary>
		/// <value>
		/// The number altura cuota.
		/// </value>
		public decimal numAlturaCuota { get; set; }

		/// <summary>
		/// Gets or sets the number capital proyectado.
		/// </summary>
		/// <value>
		/// The number capital proyectado.
		/// </value>
		public decimal numCapitalProyectado { get; set; }

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
		/// Gets or sets the number valor cuota.
		/// </summary>
		/// <value>
		/// The number valor cuota.
		/// </value>
		public decimal numValorCuota { get; set; }
	}
}
