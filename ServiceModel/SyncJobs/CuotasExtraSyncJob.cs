// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the CuotasExtraSyncJob type.
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
	using ServiceModel.BussinesLogic.WorkFlow;

	/// <summary>
	/// The Cuotas Extra Sync Job Sync Job
	/// </summary>
	/// <seealso cref="ServiceModel.SyncJobs.SyncJob{ServiceModel.Entities.Soari.CuotaExtra}" />
	public class CuotasExtraSyncJob : SyncJob<CuotaExtra>
	{
		private string ClientId;

		/// <summary>
		/// Initializes a new instance of the <see cref="CuotasExtraSyncJob"/> class.
		/// </summary>
		public CuotasExtraSyncJob()
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

			var filtro = GetProductFilter(client.ConfigurationId, TaskName);

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
			var lstcreditos = GetServiceData().Where(q => q.CuotasExtrasCreditoRepository.Count() > 0).Select(k => k.CuotasExtrasCreditoRepository);

			foreach (var credito in lstcreditos)
			{
				IEnumerable<CuotaExtra> insertData = credito
				.Select(q => new CuotaExtra
				{
					Pagada = q.Pagado,
					Pagare = q.NumeroCredito.ToString(),
					Plazo = q.Plazo,
					ValorPresente = q.ValorCuota, //Pendiente de revisar
					ValorFuturo = q.TotalCuota, //Pendiente de revisar
					//FechaPago = //Calculado
				});
				BulkInsert(insertData);
			}
		}

		private void BulkInsert(IEnumerable<CuotaExtra> processData)
		{
			using (var ctx = new Deal(ClientId).DbSoaryContext())
			{
				var repository = new GenericEntity<CuotaExtra>(ctx);
				repository.BulkInsert(processData);
			}
		}
	}
}
