// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the SyncJobTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Test.JobTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Moq;
	using Quartz;
	using ServiceModel.SyncJobs;

	/// <summary>
	/// The sync jo test
	/// </summary>
	[TestClass]
	public class SyncJobTest
	{
		/// <summary>
		/// Tasks the mock job.
		/// </summary>
		[TestMethod]
		public void TaskJob()
		{
			var job = new ServiceTaskSyncJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// The test start jobs.
		/// </summary>
		[TestMethod]
		public void TestStartJobs()
		{
			SyncJobScheduler.Start();
		}
	}
}
