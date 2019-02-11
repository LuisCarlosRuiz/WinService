// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the ContabilidadSyncJob type.
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
	/// The contbilidad Sync job
	/// </summary>
	public class ContabilidadSyncJob : SyncJob<Contabilidad>
	{
		private string ClientId;
		private GetClientData GetClientData;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditoSynJob"/> class.
		/// </summary>
		public ContabilidadSyncJob()
		{
			ClientId = GetClientId(this.GetType().Name);
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		private BalanceAgenciaSOARIPartial[] GetServiceData()
		{
			if (string.IsNullOrEmpty(ClientId))
				throw new NullReferenceException("50005 - No se encontro id del cliente");

			var client = GetClientConfiguration(ClientId);

			clientName = client.ClientName;
			TaskName = ServiceTaskName.ObtenerBalanceAgencia.ToString();

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filter = GetBalanceFilter(client.ConfigurationId);

			GetClientData = new GetClientData(client, filter);		

			var data = obj.GetBalanceAgencia(new Client.Partial.FiltroBalance()
			{
				ClaveEntidad = client.ServicedbPassword,
				SaldosMayores = long.Parse(filter.Select(
								q => Math.Round(q.FilterBalance.SaldosMayores)
								.ToString()).FirstOrDefault()),
				Anio = filter.Select(q => q.FilterBalance.Ano).FirstOrDefault(),
				Mes = filter.Select(q => q.FilterBalance.Mes).FirstOrDefault(),
				CodigoCuentas = filter.Select(q => q.CodigoCuenta).ToArray()
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

			var insertData = GetServiceData()
				.Select(q => new Contabilidad
				{
					NumeroCuenta = q.CodigoCuenta,
					FechaSaldo = q.FechaCorte,
					SaldoCuenta = q.SaldoCuenta,
					IdAgencia = hagencia.Where(
								x => x.strEquivalenciaOPA ==
								(q?.CodigoAgencia ?? string.Empty))
								?.FirstOrDefault().intId ?? 0,
					NombreCuenta = GetNombreCuenta(q.CodigoCuenta)
				}).ToList();
			BulkInsert(insertData);
		}

		/// <summary>
		/// Gets the nombre cuenta.
		/// </summary>
		/// <param name="codigoCuenta">The codigo cuenta.</param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		private string GetNombreCuenta(string codigoCuenta)
		{
			return GetClientData?.GetBalance()
				.Where(q => q.CodigoCuenta == codigoCuenta)
				?.FirstOrDefault()?.NombreCuenta ?? string.Empty;
		}

		/// <summary>
		/// Bulks the insert.
		/// </summary>
		/// <param name="processData">The process data.</param>
		private void BulkInsert(List<Contabilidad> processData)
		{
			using (var ctx = new Deal(ClientId).DbSoaryContext())
			{
				var repository = new GenericEntity<Contabilidad>(ctx);
				repository.BulkInsert(processData);
			}
		}
	}
}