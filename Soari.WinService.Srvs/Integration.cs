using System.ServiceProcess;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using ServiceModel.SyncJobs;

namespace Soari.WinService.Srvs
{
	using ServiceModel.SyncJobs;
	using System.Threading;
	

    public partial class Integration : ServiceBase
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
