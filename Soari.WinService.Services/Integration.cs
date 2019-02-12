// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Integration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Services
{
	using System.ServiceProcess;
	using System.Threading;
	using ServiceModel.SyncJobs;

	partial class Integration : ServiceBase
	{
		public Integration()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			Thread.Sleep(30 * 1000);
			SyncJobScheduler.Start();
		}

		protected override void OnStop()
		{

		}
	}
}
