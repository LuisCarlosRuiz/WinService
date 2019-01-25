// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the SyncJobTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Test.JobTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using ServiceModel.SyncJobs;

	/// <summary>
	/// The sync jo test
	/// </summary>
	[TestClass]
	public class SyncJobTest
	{
		[TestMethod]
		public void TaskJob()
		{
			ServiceTaskSyncJob Job = new ServiceTaskSyncJob();

			Job.InsertData();
		}
	}
}
