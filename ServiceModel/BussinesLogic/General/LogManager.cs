// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the LogManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.BussinesLogic.General
{
	using ServiceModel.BussinesLogic.dbService;
	using ServiceModel.Entities.dbService;
	using ServiceModel.Entities.Partial;
	using System;

	/// <summary>
	/// the log manager
	/// </summary>
	public class LogManager
	{
		/// <summary>
		/// The log last execution.
		/// </summary>
		public void ExecutionLog(string Client, string Task, string Log, bool sendMail, MessageEnum EmailHeader)
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
					SendMail(EmailHeader, executionControl);

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
	}
}
