// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the ServiceTaskSyncJob type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.SyncJobs
{
	using ServiceModel.Entities.dbService;
	using System;
	using System.Linq;
	using ServiceModel.Entities.Soari;
	using Client.Bussines;
	using Client.SoapiClient;
	using ServiceModel.Entities.Partial;
	using ServiceModel.Entities.ConectionEngine;
	using System.Collections.Generic;

	/// <summary>
	/// The credito Sync Job
	/// </summary>
	/// <seealso cref="ServiceModel.SyncJobs.SyncJob{ServiceModel.Entities.Soari.Credito}" />
	public class CreditoSynJob : SyncJob<Credito>
	{
		private string ClientId;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditoSynJob"/> class.
		/// </summary>
		public CreditoSynJob()
		{
			ClientId = GetClientId(this.GetType().Name);
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		private CreditoSOARIPartial[] GetServiceData()
		{
			if (string.IsNullOrEmpty(ClientId))
				throw new NullReferenceException("50006 - No se encontro id del cliente");

			var client = GetClientConfiguration(ClientId);

			clientName = client.ClientName;
			TaskName = ServiceTaskName.ObtenerCreditos.ToString();

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filtro = GetProductFilter(client.ConfigurationId, ServiceTaskName.ObtenerCreditos.ToString());

			return obj.GetCredito(new Client.Partial.FiltroProducto()
			{
				ClaveEntidad = client.ServicedbPassword,
				SaldosMayores = (long)filtro.SaldosMayores
			});
		}

		/// <summary>
		/// Inserts the data.
		/// </summary>
		public override void InsertData()
		{
			IEnumerable<Credito> insertData = GetServiceData()
				.Select(q => new Credito
				{
					numAnualidad = q.AnualidadCredito,
					dtmFechaDesembolso = q.FechaDesembolso,
					dtmFechaVencimiento = q.FechaVencimiento,
					numAlturaCuota = q.AlturaCredito,
					numDiasMora = q.DiasMora,
					numInteresCorriente = q.InteresCorriente,
					numInteresMora = q.InteresMora,
					numInteresCorrienteContingente = q.InteresCorrienteContingente,
					numInteresMoraContingente = q.InteresMoraContingente,
					numMontoInicial = q.CapitalInicial,
					strCategoriaFinal = q.CategoriaFinal,
					strLinea = q.CodigoLinea,
					strDestino = q.NombreDestino,
					strPagare = q.Pagare.ToString(),
					numValorGarantia = q.ValorGarantia,
					numTasaEfectiva = q.TasaEfectiva,
					numPeriodicidad = q.PeriodoCapital,
					numSaldoCapital = q.SaldoCapital,
					numSaldoAlDia = q.SaldoPonerseDia,
					numPlazo = q.PlazoCredito,
					numProvisionCapital = q.Provision,
					numProvisionInteres = q.ProvisionInteres,
					numNit = q.CedulaAsociado
				});
			BulkInsert(insertData);
		}

		private void BulkInsert(IEnumerable<Credito> processData)
		{
			using (var ctx = new Deal(ClientId).DbSoaryContext())
			{
				var repository = new GenericEntity<Credito>(ctx);
				repository.BulkInsert(processData);
			}
		}
	}
}
