// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the ModeratorSyncJob type.
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
	/// the moderator sync job
	/// </summary>
	public class ModeratorSyncJob : SyncJob<Scheduler>
	{
		/// <summary>
		/// Updates the data.
		/// </summary>
		public override void InsertData()
		{
			using (var ctx = new DbServiceContext())
			{
				var service = new GenericEntity<Scheduler>(ctx);

				var lstScheuler = ctx.Scheduler.ToList();

				foreach (var item in lstScheuler)
				{
					item.Status = "1";
					service.UpdateEntity(item);
					ctx.SaveChanges();
				}
			}
		}
	}
}
