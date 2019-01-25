// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the SyncJobScheduler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.SyncJobs
{
	using System.Configuration;
	using System.Linq;
	using System.Reflection;

	using Quartz;
	using Quartz.Impl;

	/// <summary>
	/// The sync job schduler
	/// </summary>
	public class SyncJobScheduler
	{ 
		/// <summary>
	  /// The sf.
	  /// </summary>
		private static ISchedulerFactory sf;

		/// <summary>
		/// The scheduler.
		/// </summary>
		private static IScheduler scheduler;

		/// <summary>
		/// The start.
		/// </summary>
		public static void Start()
		{
			sf = new StdSchedulerFactory();
			scheduler = sf.GetScheduler();
			AddJobs();

			scheduler?.Start();
		}

		/// <summary>
		/// The add jobs.
		/// </summary>
		private static void AddJobs()
		{
			var type = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace == "Opa.RiskManagerIntegration.Model.SyncJobs").ToList();
			foreach (var t in type)
			{
				if (t.BaseType?.Name == typeof(SyncJob<>).Name)
				{
					var cronExp = ConfigurationManager.AppSettings[t.Name] ?? "0 03 14 1/1 * ? *";
					IJobDetail job = JobBuilder.Create(t).WithIdentity($"Task{t.Name}").Build();
					ITrigger trigger = TriggerBuilder.Create().WithIdentity($"Trigger{t.Name}").WithCronSchedule(cronExp).Build();

					scheduler.ScheduleJob(job, trigger);
				}
			}
		}
	}
}
