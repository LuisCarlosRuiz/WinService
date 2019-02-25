// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the NovedadSyncJob type.
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
	using ServiceModel.Entities.ConectionEngine;
	using System.Collections.Generic;
	using ServiceModel.Entities.Partial;
	using ServiceModel.BussinesLogic.WorkFlow;
	using Partial = Entities.Partial;

	/// <summary>
	/// The novedades varias Sync job
	/// </summary>
	public class NovedadSyncJob : SyncJob<NovedadVaria>
	{
		private string ClientId;

		/// <summary>
		/// Initializes a new instance of the <see cref="AporteSyncJob"/> class.
		/// </summary>
		public NovedadSyncJob()
		{
			ClientId = GetClientId(this.GetType().Name);
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		private NovedadesSOARIPartial[] GetServiceData()
		{
			if (string.IsNullOrEmpty(ClientId))
				throw new NullReferenceException("50009 - No se encontro id del cliente");

			var client = GetClientConfiguration(ClientId);

			clientName = client.ClientName;
			TaskName = ServiceTaskName.ObtenerNovedades.ToString();

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filter = GetProductFilter(client.ConfigurationId, TaskName);

			if (filter == null)
				throw new NullReferenceException("No se encontro un filtro para este producto");

			var data = obj.GetNovedades(new Client.Partial.FiltroProducto()
			{
				ClaveEntidad = client.ServicedbPassword,
				SaldosMayores = long.Parse(Math.Round(filter.SaldosMayores).ToString())
			});

			return data;
		}

		/// <summary>
		/// Inserts the data.
		/// </summary>
		public override void InsertData()
		{
			var insertData = GetServiceData()
				.Select(q => new NovedadVaria
				{
					Consecutivo = long.Parse(q.CodigoNovedad),
					Cuota = q.Cuota,
					Identificacion =q.CedulaAsociado,
					NombreNovedad = q.TipoNovedad,
					SaldoFinal = q.SaldoFinal,
					SaldoInicial = q.SaldoInicial
				}).ToList();

			BulkInsert(insertData);
		}

		/// <summary>
		/// Bulks the insert.
		/// </summary>
		/// <param name="processData">The process data.</param>
		private void BulkInsert(List<NovedadVaria> processData)
		{
			using (var ctx = new Deal(ClientId).DbSoaryContext())
			{
				var repository = new GenericEntity<NovedadVaria>(ctx);
				repository.Truncate();
				repository.BulkInsert(processData);
			}
		}
	}
}
