﻿// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the AhorroVistaSyncJob type.
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
	using Partial = Entities.Partial;

	/// <summary>
	/// The ahorro vista Sync job
	/// </summary>
	public class AhorroVistaSyncJob : SyncJob<Ahorro>
	{
		private string ClientId;

		/// <summary>
		/// Initializes a new instance of the <see cref="AhorroVistaSyncJob"/> class.
		/// </summary>
		public AhorroVistaSyncJob()
		{
			ClientId = GetClientId(this.GetType().Name);
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		private AhorroVistaSOARIPartial[] GetServiceData()
		{
			if (string.IsNullOrEmpty(ClientId))
				throw new NullReferenceException("50009 - No se encontro id del cliente");

			var client = GetClientConfiguration(ClientId);

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filter = GetProductFilter(client.ConfigurationId, TaskName);

			if (filter == null)
				throw new NullReferenceException("No se encontro un filtro para este producto");

			var data = obj.GetAhorroVista(new Client.Partial.FiltroProducto()
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
			TaskName = Partial.ServiceTaskName.ObtenerAhorroVista.ToString();

			var hAgencia = new Homologation<Agencia>(ClientId, TaskName, clientName);
			var hTipoAhorro = new Homologation<TipoAhorro>(ClientId, TaskName, clientName);
			var hEstado = new Homologation<EstadoAhorro>(ClientId, TaskName, clientName);

			var insertData = GetServiceData()
				.Select(q => new Ahorro
				{
					dtmFechaApertura = q.FechaInicio,
					numInteresDisponible = q.InteresDisponible,
					numInteresesCausados = q.InteresCausado,
					numNit = long.Parse(q.Identificacion),
					numSaldoAhorro = q.ValorDeposito,
					numPeriodoPagoInteres = (int)q.PeriodoLiquida,
					strLinea = q.CodLinea,
					numTasaEfectiva = q.TasaCaptacion,
					numTasaNominalPeriodica = 0, //Calculado
					strCuenta = q.NumeroDeposito,
					numAño = q.FechaUtlimaTransaccion.Year,
					numPeriodo = (int)q.PeriodoLiquida,
					dtmFechaVencimiento = DateTime.Parse("01/01/1900"), //Simulado
					idAgencia = (int)hAgencia.GetHomologation(q.Agencia, "strNombreAgencia", "intId"),
					idTipoAhorro = (int)hTipoAhorro.GetHomologation(Partial.TipoAhorro.AhorroVista.ToString(), "strNombreTipoAhorro", "intId"),
					idEstadoAhorro = (int)hEstado.GetHomologation(q.Estado, "strNombreEstadoAhorro", "intId")
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
				repository.BulkInsert(processData);
			}
		}
	}
}
