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
	using ServiceModel.Entities.Partial;
	using ServiceModel.SyncJobs;
	using System.Collections.Generic;
	using System.Configuration;

	/// <summary>
	/// The sync jo test
	/// </summary>
	[TestClass]
	public class SyncJobTest
	{
		/// <summary>
		/// Moderators the synchronize job test.
		/// </summary>
		[TestMethod]
		public void ModeratorSyncJobTest()
		{
			var job = new ModeratorSyncJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// Tasks the mock job.
		/// </summary>
		[TestMethod]
		public void TaskJobTest()
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

		/// <summary>
		/// Settingses the test.
		/// </summary>
		[TestMethod]
		public void SettingsTest()
		{
			var lstSettings = ConfigurationManager.AppSettings;

			var lst = new List<JobPartial>();

			foreach (var item in lstSettings.AllKeys)
			{
				if (item.Contains("SyncJob"))
				{
					lst.Add(new JobPartial {
						Concecutivo = item.Split('-')[0].Trim(),
						TaskName = item.Split('-')[1].Trim(),
						ClientId = ConfigurationManager.AppSettings[item].Split('$')[0].Trim(),
						CronExpression = ConfigurationManager.AppSettings[item].Split('$')[1].Trim()
					});
				}
			}

			if (lst.Count < 0)
				Assert.Inconclusive();
		}
	}
}
