﻿// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the SyncJobTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.SyncJobs
{
	using Quartz;
	using ServiceModel.Entities.dbService;
	using ServiceModel.Entities.Partial;
	using ServiceModel.BussinesLogic.dbService;
	using ServiceModel.BussinesLogic.General;
	using System;
	using System.Linq;

	/// <summary>
	/// the sync job 
	/// </summary>
	public abstract class SyncJob<TEntity> : IJob
	{
		public abstract void InsertData();

		/// <summary>
		/// Executes the specified mock context.
		/// </summary>
		/// <param name="mockContext">The mock context.</param>
		public void Execute(IJobExecutionContext mockContext)
		{
			string clientName = string.Empty;
			try
			{
				InsertData();
				ExecutionLog(clientName, TaskEnum.TaskInsert.ToString(), MessageEnum.Success.ToString(), false);
			}
			catch (Exception ex)
			{
				ExecutionLog(clientName, TaskEnum.TaskInsert.ToString(), ex.ToString(), true);
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
					SendMail(MessageEnum.FatalError, executionControl);

				repository.InsertEntity(executionControl);

				ctx.SaveChanges();
			}
		}

		/// <summary>
		/// Sends the mail.
		/// </summary>
		/// <param name="mesage">The mesage.</param>
		/// <param name="executionControl">The execution control.</param>
		public void SendMail(MessageEnum mesage, ExecutionControl executionControl)
		{
			var lstUser = new UserAdminBL().GetListUserAdminByStateActive();

			foreach (var item in lstUser)
			{
				new MailManager().MailBuilder(mesage.ToString(), executionControl, item);
			}
		}

		/// <summary>
		/// Gets the identifier cliente.
		/// </summary>
		/// <returns></returns>
		public string GetClientId(string JobName)
		{
			using (var ctx = new DbServiceContext())
			{
				var scheduler = ctx.Scheduler.Where(q => q.TaskName == JobName && q.Status == "1")
					.OrderBy(q => q.Consecutive).FirstOrDefault();

				if (scheduler == null)
					throw new Exception();

				scheduler.Status = "0";
				new GenericEntity<Scheduler>(ctx).UpdateEntity(scheduler);
				ctx.SaveChanges();

				return scheduler.ClientId;
			}
		}
	}
}
