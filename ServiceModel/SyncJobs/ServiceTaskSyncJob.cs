// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the ServiceTaskSyncJob type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.SyncJobs
{
	using Client.Util;
	using ServiceModel.Entities.dbService;
	using ServiceModel.Entities.Partial;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Linq;

	/// <summary>
	/// the service task sync job
	/// </summary>
	public class ServiceTaskSyncJob : SyncJob<ServiceTask>
	{
		private Global objGlobal;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceTaskSyncJob"/> class.
		/// </summary>
		public ServiceTaskSyncJob()
		{
			objGlobal = new Global();
		}

		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <returns></returns>
		private List<string> GetData()
		{
			var methodList = objGlobal.GetServiceAtributes().Where(q => !q.Name.Contains("Async"));
			List<string> methodNames = new List<string>();

			foreach (var item in methodList)
			{
				methodNames.Add(item.Name);
			}

			return methodNames;
		}

		/// <summary>
		/// Inserts the data.
		/// </summary>
		public void InsertData()
		{
			try
			{
				using (var ctx = new DbServiceContext())
				{
					var lstTask = ctx.ServiceTask.Select(q => q.TaskName).ToList();
					var repository = new GenericEntity<ServiceTask>(ctx);

					foreach (var item in GetData())
					{
						if (!lstTask.Contains(item))
							repository.InsertEntity(new ServiceTask()
							{
								TaskId = Guid.NewGuid(),
								TaskName = item
							});

					}

					ctx.SaveChangesAsync();

					ExecutionLog(string.Empty, TaskEnum.TaskInsert.ToString(), MessageEnum.Success.ToString());
				}
			}
			catch (Exception ex)
			{
				ExecutionLog(string.Empty, TaskEnum.TaskInsert.ToString(), ex.ToString());
			}
		}
	}
}
