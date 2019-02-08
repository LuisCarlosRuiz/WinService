// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the NitSyncJob type.
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
	/// the nit sync job
	/// </summary>
	/// <seealso cref="ServiceModel.SyncJobs.SyncJob{ServiceModel.Entities.Soari.Credito}" />
	public class NitSyncJob : SyncJob<Nit>
	{
		private string ClientId;

		/// <summary>
		/// Initializes a new instance of the <see cref="CreditoSynJob"/> class.
		/// </summary>
		public NitSyncJob()
		{
			ClientId = GetClientId(this.GetType().Name);
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		private AsociadoSOARIPartial[] GetServiceData()
		{
			if (string.IsNullOrEmpty(ClientId))
				throw new NullReferenceException("50007 - No se encontro id del cliente");

			var client = GetClientConfiguration(ClientId);

			clientName = client.ClientName;
			TaskName = ServiceTaskName.ObtenerAsociado.ToString();

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filtro = GetAsociadoFilter(client.ConfigurationId);

			return obj.GetAsociado(new Client.Partial.FiltroAsociado()
			{
				ClaveEntidad = client.ServicedbPassword,
				DesdeFechaIngreso = filtro.FechaActualizacion
			});
		}

		/// <summary>
		/// Inserts the data.
		/// </summary>
		public override void InsertData()
		{
			var hData = new HomologationData(ClientId);
			var hAgencia = hData.GetHomologationAgencia();
			var hciudad = hData.GetHomologationCiudad();
			var hPais = hData.GetHomologationPais();
			var hTipoContrato = hData.GetHomologationTipoContrato();
			var hDepartamento = hData.GetHomologationDepartamento();
			var hGenero = hData.GetHomologationGenero();
			var hTipoIdentificacion = hData.GetHomologationTipoIdentificacion();

			IEnumerable<Nit> insertData = GetServiceData()
				.Select(q => new Nit
				{
					numNit = q.CedulaAsociado,
					dtmFechaIngreso = q.FechaIngresoEntidad,
					numEstrato = int.Parse(q.Estrato),
					numNivelIngresos = 0, //Calculado
					numPersonasCargo = q.NumPersonasACargo,
					numSalario = q.Salario,
					numTotalGastos = TotalGastos(q),
					dtmFechaNacimiento = q.FechaNacimiento,
					numTotalOtrosIngresos = TotalOtrosIngresos(q),
					strBarrio = q.BarrioNombre,
					strEmpleado = q.Empleado,
					strNombreEmpresaTrabajo = q.NombreEmpresa,
					strNombreIntegrado = $"{q.Nombres} {q.PrimerApellido} {q.SegundoApellido}",
					strPrimerApellido = q.PrimerApellido,
					strSegundoApellido = q.SegundoApellido,
					strPrimerNombre = q.Nombres.Split(' ')[0],
					strSegundoNombre = q.Nombres?.Split(' ')[1] ?? string.Empty,
					strZona = q.NombreZona,
					strPEPs = q.PersonaExpuesta,
					strCodigoEmpresaTrabajo = q.CodidoEmpresaLabora,
					idAgencia = hAgencia.Where(x => x.strEquivalenciaOPA == q.CodigoAgencia.ToString())
								?.FirstOrDefault()?.intId ?? 0,
					idCiudad = hciudad.Where(x => x.strEquivalenciaOPA == q.CiudadResidenciaNombre.ToString())
								?.FirstOrDefault()?.intId ?? 0, //Pendiente por codigo  
					idPais = hPais.Where(x => x.strEquivalenciaOPA == q.PaisResidenciaNombre.ToString())
								?.FirstOrDefault()?.intId ?? 0, //Pendiente por codigo  
					idTipoContrato = hTipoContrato.Where(x => x.strEquivalenciaOPA == q.TipoContrato.ToString())
								?.FirstOrDefault()?.intId ?? 0, //Pendiente por codigo  
					idDepartamento = hDepartamento.Where(x => x.strEquivalenciaOPA == q.NombreDepartamentoResidencia.ToString())
								?.FirstOrDefault()?.intId ?? 0, //Pendiente por codigo
					idGenero = hGenero.Where(x => x.strEquivalenciaOPA == q.Sexo.ToString())
								?.FirstOrDefault()?.intId ?? 0, //Pendiente por codigo
					idTipoIdentificacion = hTipoIdentificacion.Where(x => x.strEquivalenciaOPA == q.TipoIdentificacion.ToString())
								?.FirstOrDefault()?.intId ?? 0, //Pendiente por codigo
				});
			BulkInsert(insertData);
		}

		/// <summary>
		/// Totals the otros ingresos.
		/// </summary>
		/// <param name="q">The q.</param>
		/// <returns></returns>
		private decimal TotalOtrosIngresos(AsociadoSOARIPartial q)
		{
			return decimal.Parse((q.Arriendos + q.Bonificaciones + q.Comisiones +
									q.Dividendos + q.Honorarios + q.InteresInversiones +
									q.OtrosIngresos + q.Pensiones + q.Refrigerio +
									q.SubsidioLocalizacion + q.Sueldo + q.UtilidadNegocio).ToString());

		}

		/// <summary>
		/// Totals the gastos.
		/// </summary>
		/// <param name="q">The q.</param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		private decimal TotalGastos(AsociadoSOARIPartial q)
		{
			return q.GastoAlimentacion + q.GastoArriendo + q.GastoCuotaDomestica +
					q.GastoDeuda + q.GastoEducacion + q.GastoOtroNegocios +
					q.GastoOtroPrestamo + q.GastoPrestamoVehiculo + q.GastoPrestamoVivienda +
					q.GastoSalud + q.GastoServicioPublico + q.GastoTrajetaCredito +
					q.GastoTransporte;
		}

		private void BulkInsert(IEnumerable<Nit> processData)
		{
			using (var ctx = new Deal(ClientId).DbSoaryContext())
			{
				var repository = new GenericEntity<Nit>(ctx);
				repository.BulkInsert(processData);
			}
		}
	}
}
