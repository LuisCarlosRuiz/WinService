// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the AporteSyncJob type.
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

	/// <summary>
	/// The aporte Sync Job
	/// </summary>
	public class AporteSyncJob : SyncJob<Aporte>
	{
		private string ClientId;
		private GetClientData GetClientData;

		/// <summary>
		/// Initializes a new instance of the <see cref="AporteSyncJob"/> class.
		/// </summary>
		public AporteSyncJob()
		{
			ClientId = GetClientId(this.GetType().Name);
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		private AporteSOARIPartial[] GetServiceData()
		{
			if (string.IsNullOrEmpty(ClientId))
				throw new NullReferenceException("50009 - No se encontro id del cliente");

			var client = GetClientConfiguration(ClientId);

			clientName = client.ClientName;
			TaskName = ServiceTaskName.ObtenerAporte.ToString();

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filter = GetProductFilter(client.ConfigurationId, TaskName);

			var data = obj.GetAporte(new Client.Partial.FiltroProducto()
			{
				ClaveEntidad = client.ServicedbPassword,
				SaldosMayores = long.Parse(filter.SaldosMayores.ToString())				
			});

			return data;
		}

		/// <summary>
		/// Inserts the data.
		/// </summary>
		public override void InsertData()
		{
			var hdata = new HomologationData(ClientId);
			var hagencia = hdata.GetHomologationAgencia();
			var hTipoAporte = hdata.GetHomologationTipoAporte();

			var insertData = GetServiceData()
				.Select(q => new Aporte
				{
					dtmFechaApertura = q.FechaApertura,
					numCuotaAhorro = q.ValorAporte,
					numEstado = int.Parse(q.Estado), //Pendiente por revisar
					numNit = long.Parse(q.Identificacion),
					numSaldoAporte = q.SaldoAhorro,
					strNumeroCuenta = q.NumeroCuentaAporte,
					strLinea =q.CodigoLinea,
					numValorRevalorizacion = 0,
					idAgencia = (int)GetHomologation(hagencia, q.Agencia, "strNombreAgencia", "intId"),
					idTipoAporte = (int)GetHomologation(hTipoAporte, q.Agencia, "strNombreTipoAporte", "intId")
				}).ToList();
			BulkInsert(insertData);
		}

		/// <summary>
		/// Bulks the insert.
		/// </summary>
		/// <param name="processData">The process data.</param>
		private void BulkInsert(List<Aporte> processData)
		{
			using (var ctx = new Deal(ClientId).DbSoaryContext())
			{
				var repository = new GenericEntity<Aporte>(ctx);
				repository.Truncate();
				repository.BulkInsert(processData);
			}
		}
	}
}
