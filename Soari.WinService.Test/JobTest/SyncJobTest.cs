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
		/// Creditoes the syn job test.
		/// </summary>
		[TestMethod]
		public void CreditoSynJobTest()
		{
			var job = new CreditoSynJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// Creditoes the syn job test.
		/// </summary>
		[TestMethod]
		public void NitSyncJobTest()
		{
			var job = new NitSyncJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// Aportes the synchronize job test.
		/// </summary>
		[TestMethod]
		public void AporteSyncJobTest()
		{
			var job = new AporteSyncJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// Contabilidads the synchronize job test.
		/// </summary>
		[TestMethod]
		public void ContabilidadSyncJobTest()
		{
			var job = new ContabilidadSyncJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// Ahorroes the contractual synchronize job test.
		/// </summary>
		[TestMethod]
		public void AhorroContractualSyncJobTest()
		{
			var job = new AhorroContractualSyncJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// Ahorroes the vista synchronize job test.
		/// </summary>
		[TestMethod]
		public void AhorroVistaSyncJobTest()
		{
			var job = new AhorroVistaSyncJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// Ahorroes the termino synchronize job test.
		/// </summary>
		[TestMethod]
		public void AhorroTerminoSyncJobTest()
		{
			var job = new AhorroTerminoSyncJob();
			var mockContext = new Mock<IJobExecutionContext>().Object;
			job.Execute(mockContext);
		}

		/// <summary>
		/// Cuotases the extra synchronize job test.
		/// </summary>
		[TestMethod]
		public void CuotasExtraSyncJobTest()
		{
			var job = new CuotasExtraSyncJob();
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
