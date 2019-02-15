// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the AhorroTerminoSyncJob type.
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
	/// The ahorro a termino Sync job
	/// </summary>
	class AhorroTerminoSyncJob : SyncJob<Ahorro>
	{
		private string ClientId;

		/// <summary>
		/// Initializes a new instance of the <see cref="AporteSyncJob"/> class.
		/// </summary>
		public AhorroTerminoSyncJob()
		{
			ClientId = GetClientId(this.GetType().Name);
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		private AhorroTerminoSOARIPartial[] GetServiceData()
		{
			if (string.IsNullOrEmpty(ClientId))
				throw new NullReferenceException("50009 - No se encontro id del cliente");

			var client = GetClientConfiguration(ClientId);

			clientName = client.ClientName;
			TaskName = ServiceTaskName.ObtenerAhorroTermino.ToString();

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filter = GetProductFilter(client.ConfigurationId, TaskName);

			if (filter == null)
				throw new NullReferenceException("No se encontro un filtro para este producto");

			var data = obj.GetAhorroTermino(new Client.Partial.FiltroProducto()
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
			var hdata = new HomologationData(ClientId);
			var hAgencia = hdata.GetHomologationAgencia();
			var hTipoAhorro = hdata.GetHomologationTipoAhorro();

			var insertData = GetServiceData()
				.Select(q => new Ahorro
				{
					dtmFechaApertura = q.FechaInicio,
					numInteresDisponible = q.InteresDisponible,
					numInteresesCausados = q.InteresCausado,
					numNit = long.Parse(q.Identificacion),
					numSaldoAhorro = q.ValorDeposito,
					strLinea = q.CodLinea,
					numTasaEfectiva = q.TasaInteres,
					numPlazo = q.Plazo,
					dtmFechaVencimiento = q.FechaVencimiento,
					numPeriodoPagoInteres = q.PeriodoInteres,					
					numTasaNominalPeriodica = 0, //Calculado
					strCuenta = q.NumeroDeposito,
					idAgencia = (int)GetHomologation(hAgencia, q.Agencia, "strNombreAgencia", "intId"),
					idTipoAhorro = (int)GetHomologation(hTipoAhorro, Partial.TipoAhorro.AhorroTemino.ToString(), "strNombreTipoAhorro", "intId"),
				}).ToList();

			BulkInsert(insertData);
		}

		/// <summary>
		/// Bulks the insert.
		/// </summary>
		/// <param name="processData">The process data.</param>
		private void BulkInsert(List<Ahorro> processData)
		{
			using (var ctx = new Deal(ClientId).DbSoaryContext())
			{
				var repository = new GenericEntity<Ahorro>(ctx);
				repository.Truncate();
				repository.BulkInsert(processData);
			}
		}
	}
}
