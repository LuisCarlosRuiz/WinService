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
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// the service task sync job
	/// </summary>
	public class ServiceTaskSyncJob
	{
		private Global objGlobal;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceTaskSyncJob"/> class.
		/// </summary>
		public ServiceTaskSyncJob(string _ClientId)
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

		private async void InsertData()
		{
			using (var ctx = new DbServiceContext())
			{
				throw new NotImplementedException();
				await ctx.SaveChangesAsync();
			}
		}
	}
}
