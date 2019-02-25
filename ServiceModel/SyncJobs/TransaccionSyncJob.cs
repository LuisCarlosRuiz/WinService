// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the TransaccionSyncJob type.
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
	/// The transacciones Sync job
	/// </summary>
	public class TransaccionSyncJob : SyncJob<NovedadVaria>
	{
		private string ClientId;

		/// <summary>
		/// Initializes a new instance of the <see cref="TransaccionSyncJob"/> class.
		/// </summary>
		public TransaccionSyncJob()
		{
			ClientId = GetClientId(this.GetType().Name);
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		private TransaccionesSOARIPartial[] GetServiceData()
		{
			if (string.IsNullOrEmpty(ClientId))
				throw new NullReferenceException("50009 - No se encontro id del cliente");

			var client = GetClientConfiguration(ClientId);

			clientName = client.ClientName;
			TaskName = ServiceTaskName.ObtenerTransacciones.ToString();

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filter = GetTransaccionFilter(client.ConfigurationId);

			if (filter == null)
				throw new NullReferenceException("No se encontro un filtro para este producto");

			var data = obj.GetTransacciones(new Client.Partial.FiltroTransacciones()
			{
				ClaveEntidad = client.ServicedbPassword,
				MovimientosDesde = filter.MovimientosDesde,
				MovimientosHasta = filter.MovimientosHasta
			});

			return data;
		}

		/// <summary>
		/// Inserts the data.
		/// </summary>
		public override void InsertData()
		{
			var hData = new HomologationData(ClientId);
			var hAgencia = hData.GetHomologationAgencia();
			var hTipoProducto = hData.GetHomologationTipoProductoTransaccion();
			var hTipoTransaccion = hData.GetHomologationTipoTransaccion();

			var insertData = GetServiceData()
				.Select(q => new Transacciones
				{
					idAgencia = (int)GetHomologation(hAgencia, q.CodigoOficina, "strEquivalenciaOPA", "intId"),
					idTipoProducto = (int)GetHomologation(hTipoProducto, q.TipoProducto, "strNombreTipoProducto", "intId"),
					idTipoTransaccion = (int)GetHomologation(hTipoTransaccion, q.TipoTransaccion, "strNombreTipoTransaccion", "intId"),
					numNit = long.Parse(q.IdentificacionTitular),
					strLineaProducto = q.CodigoLinea,
					strNumeroCuenta = q.NumeroProducto,
					strNumeroRecibo = q.NumeroTransaccion,
					numValorEfectivo = q.ValorTransaccion,
					strOperadorTransaccion = q.NombreEjecutor,
					strLugarTransaccion = q.LugarTransaccion,
					dtmFechaHora = q.FechaTransaccion
				}).ToList();

			BulkInsert(insertData);
		}

		/// <summary>
		/// Bulks the insert.
		/// </summary>
		/// <param name="processData">The process data.</param>
		private void BulkInsert(List<Transacciones> processData)
		{
			using (var ctx = new Deal(ClientId).DbSoaryContext())
			{
				var repository = new GenericEntity<Transacciones>(ctx);
				repository.Truncate();
				repository.BulkInsert(processData);
			}
		}
	}
}
