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
		/// Initializes a new instance of the <see cref="NitSyncJob"/> class.
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

			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var filtro = GetAsociadoFilter(client.ConfigurationId);

			var data = obj.GetAsociado(new Client.Partial.FiltroAsociado()
			{
				ClaveEntidad = client.ServicedbPassword,
				DesdeFechaIngreso = filtro.FechaActualizacion
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
			TaskName = ServiceTaskName.ObtenerAsociado.ToString();

			var hAgencia = new Homologation<Agencia>(ClientId, TaskName, clientName);
			var hciudad = new Homologation<Ciudad>(ClientId, TaskName, clientName);
			var hPais = new Homologation<Pais>(ClientId, TaskName, clientName);
			var hTipoContrato = new Homologation<TipoContrato>(ClientId, TaskName, clientName);
			var hDepartamento = new Homologation<Departamento>(ClientId, TaskName, clientName);
			var hGenero = new Homologation<Genero>(ClientId, TaskName, clientName);
			var hTipoIdentificacion = new Homologation<TipoIdentificacion>(ClientId, TaskName, clientName);
			var hActividadEconimica = new Homologation<ActividadEconomica>(ClientId, TaskName, clientName);
			var hEstadoCivil = new Homologation<EstadoCivil>(ClientId, TaskName, clientName);
			var hNivelEstudios = new Homologation<NivelEstudio>(ClientId, TaskName, clientName);

			var data = GetServiceData();

			List<Nit> insertData = data
				.Select(q => new Nit
				{
					numNit = q?.CedulaAsociado ?? 0,
					dtmFechaIngreso = q.FechaIngresoEntidad,
					numEstrato = !string.IsNullOrEmpty(q.Estrato) ? int.Parse(q.Estrato) : 0,
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
					strPrimerNombre = q.Nombres.Split(' ').Count() > 0 ?
										q?.Nombres.Split(' ')[0] : string.Empty,
					strSegundoNombre = q.Nombres.Split(' ').Count() > 1 ?
										q?.Nombres.Split(' ')[1] : string.Empty,
					strZona = q.NombreZona,
					strPEPs = q.PersonaExpuesta,
					strExonerado = string.Empty, //No se cuenta en el servicio
					strEmail = q.Email,
					strDireccion = q.DireccionResidencia,
					strTelefono = q.Telefono,
					strCodigoEmpresaTrabajo = q.CodidoEmpresaLabora,
					idAgencia = (int)hAgencia.GetHomologation(q.CodigoAgencia, "strEquivalenciaOPA", "intId"),
					idCiudad = (int)hciudad.GetHomologation(q.CiudadResidenciaNombre, "strNombreCiudad", "intId"),
					idPais = (int)hPais.GetHomologation(q.PaisResidenciaNombre, "strNombrePais", "intId"),
					idTipoContrato = (int)hTipoContrato.GetHomologation(q.TipoContrato, "strNombreTipoContrato", "intId"),
					idDepartamento = (int)hDepartamento.GetHomologation(q.NombreDepartamentoResidencia, "strNombreDepartamento", "intId"),
					idGenero = (int)hGenero.GetHomologation(q.Sexo, "strNombreGenero", "intId"),
					idTipoIdentificacion = (int)hTipoIdentificacion.GetHomologation(q.TipoIdentificacion, "strNombreTipoIdentificacion", "intId"),
					idActividadEconomica = (int)hActividadEconimica.GetHomologation(q.CodigoCIIU, "strEquivalenciaOPA", "intId"),
					idEstadoCivil = (int)hEstadoCivil.GetHomologation(q.EstadoCivil, "strNombreEstadoCivil", "intId"),
					idNivelEstudio = (int)hNivelEstudios.GetHomologation(q.Estudios, "strNombreNivelEstudio", "intId")
				}).ToList();

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

		/// <summary>
		/// Bulks the insert.
		/// </summary>
		/// <param name="processData">The process data.</param>
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
