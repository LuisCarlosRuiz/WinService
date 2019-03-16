// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the SyncJobTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.SyncJobs
{
	using Quartz;
	using ServiceModel.Entities.dbService;
	using Partial = ServiceModel.Entities.Partial;
	using ServiceModel.BussinesLogic.dbService;
	using ServiceModel.BussinesLogic.General;
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using ServiceModel.Entities.ConectionEngine;
	using System.Data.Entity;
	using ServiceModel.Entities.Soari;

	/// <summary>
	/// the sync job 
	/// </summary>
	public abstract class SyncJob<TEntity> : IJob
	{
		public abstract void InsertData();
		public string TaskName;
		public string clientName;

		/// <summary>
		/// Executes the specified mock context.
		/// </summary>
		/// <param name="mockContext">The mock context.</param>
		public void Execute(IJobExecutionContext mockContext)
		{
			try
			{
				InsertData();
				new LogManager().ExecutionLog(clientName ?? string.Empty, TaskName ?? string.Empty, Partial.MessageEnum.Success.ToString(), false, Partial.MessageEnum.Success);
			}
			catch (Exception ex)
			{
				new LogManager().ExecutionLog(clientName ?? string.Empty, TaskName ?? string.Empty, ex.ToString(), true, Partial.MessageEnum.FatalError);
			}
		}

		/// <summary>
		/// Gets the task identifier.
		/// </summary>
		/// <param name="TaskName">Name of the task.</param>
		/// <returns></returns>
		internal ServiceTask GetTaskId(string TaskName)
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.ServiceTask.Where(q => q.TaskName == TaskName).FirstOrDefault();
			}
		}

		/// <summary>
		/// Gets the client configuration.
		/// </summary>
		/// <param name="clientId">The client identifier.</param>
		/// <returns></returns>
		internal ClientConfiguration GetClientConfiguration(string clientId)
		{
			using (var ctx = new DbServiceContext())
			{
				AesManager msg = new AesManager();
				var client = ctx.ClientConfiguration.Where(q => q.JobId == clientId
				&& q.State == "A").FirstOrDefault();

				return new ClientConfiguration
				{
					ClientName = client.ClientName,
					ConfigurationId = client.ConfigurationId,
					JobId = client.JobId,
					DBName = client.DBName,
					DBPassword = msg.Decrypt(client.DBPassword),
					DBServerName = client.DBServerName,
					DBUser = client.DBUser,
					ServicedbPassword = msg.Decrypt(client.ServicedbPassword),
					ServicePassword = msg.Decrypt(client.ServicePassword),
					ServiceUrl = client.ServiceUrl,
					ServiceUser = client.ServiceUser,
					State = client.State
				};
			}
		}

		/// <summary>
		/// Gets the identifier cliente.
		/// </summary>
		/// <returns></returns>
		internal string GetClientId(string JobName)
		{
			using (var ctx = new DbServiceContext())
			{
				var scheduler = ctx.Scheduler.Where(q => q.TaskName == JobName && q.Status == "1")
					.OrderBy(q => q.Consecutive).FirstOrDefault();

				if (scheduler == null)
					throw new NullReferenceException("50008 - No hay tareas asignadas al job");

				scheduler.Status = "0";
				new GenericEntity<Scheduler>(ctx).UpdateEntity(scheduler);
				ctx.SaveChanges();

				return scheduler.ClientId;
			}
		}

		/// <summary>
		/// Gets the product filter.
		/// </summary>
		/// <param name="filtroProducto">The filtro producto.</param>
		/// <returns></returns>
		internal FilterProducto GetProductFilter(Guid ConfigurationId, string TaskName)
		{
			Guid TaskId = GetTaskId(TaskName).TaskId;

			using (var ctx = new DbServiceContext())
			{
				return ctx.FilterProducto.Where(q => q.ConfigurationId == ConfigurationId &&
									q.TaskId == TaskId).FirstOrDefault();
			}
		}

		/// <summary>
		/// Gets the product filter.
		/// </summary>
		/// <param name="filtroProducto">The filtro producto.</param>
		/// <returns></returns>
		internal FilterAsociado GetAsociadoFilter(Guid ConfigurationId)
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.FilterAsociado.Where(q => q.ConfigurationId == ConfigurationId).FirstOrDefault();
			}
		}

		/// <summary>
		/// Gets the balance filter.
		/// </summary>
		/// <param name="ConfigurationId">The configuration identifier.</param>
		/// <returns></returns>
		internal List<Cuenta> GetBalanceFilter(Guid ConfigurationId)
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.Cuenta.Include("FilterBalance").Where(q => q.FilterBalance.ConfiguracionId == ConfigurationId).ToList();
			}
		}

		/// <summary>
		/// Gets the transaccion filter.
		/// </summary>
		/// <param name="ConfigurationId">The configuration identifier.</param>
		/// <returns></returns>
		internal FilterTransaccion GetTransaccionFilter(Guid ConfigurationId)
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.FilterTransaccion.Where(q => q.ConfigurationId == ConfigurationId).FirstOrDefault();
			}
		}
	}
}
