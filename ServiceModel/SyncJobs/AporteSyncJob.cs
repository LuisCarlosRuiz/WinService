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

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filter = GetProductFilter(client.ConfigurationId, TaskName);

			if (filter == null)
				throw new NullReferenceException("No se encontro un filtro para este producto");

			var data = obj.GetAporte(new Client.Partial.FiltroProducto()
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
			var client = GetClientConfiguration(ClientId);

			clientName = client.ClientName;
			TaskName = ServiceTaskName.ObtenerAporte.ToString();

			var hAgencia = new Homologation<Agencia>(ClientId, TaskName, clientName);
			var hTipoAporte = new Homologation<TipoAporte>(ClientId, TaskName, clientName);

			var insertData = GetServiceData()
				.Select(q => new Aporte
				{
					dtmFechaApertura = q.FechaApertura,
					numCuotaAhorro = q.ValorAporte,
					numEstado = (int)Enum.Parse(typeof(EstadoAporte), q.Estado),
					numNit = long.Parse(q.Identificacion),
					numSaldoAporte = q.SaldoAhorro,
					strNumeroCuenta = q.NumeroCuentaAporte,
					strLinea = q.CodigoLinea,
					numValorRevalorizacion = 0,
					idAgencia = (int)hAgencia.GetHomologation(q.Agencia, "strNombreAgencia", "intId"),
					idTipoAporte = (int)hTipoAporte.GetHomologation(q.TipoAporte, "strNombreTipoAporte", "intId")
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
				repository.BulkInsert(processData);
			}
		}
	}
}
