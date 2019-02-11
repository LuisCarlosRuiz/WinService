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
				ExecutionLog(clientName ?? string.Empty, TaskName ?? string.Empty, Partial.MessageEnum.Success.ToString(), false);
			}
			catch (Exception ex)
			{
				ExecutionLog(clientName ?? string.Empty, TaskName ?? string.Empty, ex.ToString(), true);
			}
		}

		/// <summary>
		/// The log last execution.
		/// </summary>
		public void ExecutionLog(string Client, string Task, string Log, bool sendMail)
		{
			using (var ctx = new DbServiceContext())
			{
				var repository = new GenericEntity<ExecutionControl>(ctx);

				var executionControl = new ExecutionControl()
				{
					Task = Task,
					ExecutionDate = DateTime.Now,
					ExecutionId = Guid.NewGuid(),
					Log = Log,
					Client = Client
				};

				if (sendMail)
					SendMail(Partial.MessageEnum.FatalError, executionControl);

				repository.InsertEntity(executionControl);

				ctx.SaveChanges();
			}
		}

		/// <summary>
		/// Sends the mail.
		/// </summary>
		/// <param name="mesage">The mesage.</param>
		/// <param name="executionControl">The execution control.</param>
		public void SendMail(Partial.MessageEnum mesage, ExecutionControl executionControl)
		{
			var lstUser = new UserAdminBL().GetListUserAdminByStateActive();

			foreach (var item in lstUser)
			{
				new MailManager().MailBuilder(mesage.ToString(), executionControl, item);
			}
		}

		internal ServiceTask GetTaskId(string TaskName)
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.ServiceTask.Where(q => q.TaskName == TaskName).FirstOrDefault();
			}
		}

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
	}
}
