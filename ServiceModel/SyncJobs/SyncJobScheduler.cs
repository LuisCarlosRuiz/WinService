// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the SyncJobScheduler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.SyncJobs
{
	using System;
	using System.Collections.Generic;
	using System.Configuration;
	using System.Linq;
	using System.Reflection;

	using Quartz;
	using Quartz.Impl;
	using ServiceModel.Entities.dbService;
	using ServiceModel.Entities.Partial;

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
			ManageJobs();

			scheduler?.Start();
		}

		/// <summary>
		/// Manages the jobs.
		/// </summary>
		private static void ManageJobs()
		{
			TruncateScheduler();

			var type = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.Namespace == "ServiceModel.SyncJobs").ToList();
			foreach (var t in type)
			{
				if (t.BaseType?.Name == typeof(SyncJob<>).Name)
				{
					if (t.Name == "ModeratorSyncJob")
						AddJob(t, t.Name, ConfigurationManager.AppSettings[t.Name] ?? "0 59 23 1/1 * ? *");
					else
						foreach (var jobItem in GetJob(t.Name))
						{
							SaveScheduler(jobItem);

							string tName = $"{jobItem.Concecutivo}-{jobItem.TaskName}.{jobItem.ClientId}";
							var cronExp = jobItem?.CronExpression ?? "0 44 16 / * ? *";

							AddJob(t, tName, cronExp);
						}
				}
			}
		}

		/// <summary>
		/// Adds the job.
		/// </summary>
		/// <param name="t">The t.</param>
		/// <param name="tName">Name of the t.</param>
		/// <param name="cronExp">The cron exp.</param>
		public static void AddJob(Type t, string tName, string cronExp)
		{
			IJobDetail job = JobBuilder.Create(t).WithIdentity($"Task{tName}").Build();
			ITrigger trigger = TriggerBuilder.Create().WithIdentity($"Trigger{tName}")
								.WithCronSchedule(cronExp).Build();

			scheduler.ScheduleJob(job, trigger);
		}

		/// <summary>
		/// Gets the list job.
		/// </summary>
		/// <param name="EndsWith">The ends with.</param>
		/// <returns></returns>
		private static List<JobPartial> GetJob(string EndsWith)
		{
			var lstSettings = ConfigurationManager.AppSettings;
			var lst = new List<JobPartial>();

			foreach (var item in lstSettings.AllKeys)
			{
				if (item.EndsWith(EndsWith))
				{
					lst.Add(new JobPartial
					{
						Concecutivo = item.Split('-')[0].Trim(),
						TaskName = item.Split('-')[1].Trim(),
						ClientId = ConfigurationManager.AppSettings[item].Split('$')[0].Trim(),
						CronExpression = ConfigurationManager.AppSettings[item].Split('$')[1].Trim()
					});
				}
			}

			return lst;
		}

		/// <summary>
		/// Saves the scheduler.
		/// </summary>
		/// <param name="job">The job.</param>
		private static void SaveScheduler(JobPartial job)
		{
			using (var ctx = new DbServiceContext())
			{
				var repository = new GenericEntity<Scheduler>(ctx);

				var scheduler = new Scheduler
				{
					SchedulerId = Guid.NewGuid(),
					ClientId = job.ClientId,
					Consecutive = int.Parse(job.Concecutivo),
					Status = "1",
					TaskName = job.TaskName
				};

				repository.InsertEntity(scheduler);

				ctx.SaveChanges();
			}
		}

		/// <summary>
		/// Truncates the scheduler.
		/// </summary>
		private static void TruncateScheduler()
		{
			using (var ctx = new DbServiceContext())
			{
				new GenericEntity<Scheduler>(ctx).Truncate();
			}
		}
	}
}
