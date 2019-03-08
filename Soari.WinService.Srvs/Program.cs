
using System.ServiceProcess;

namespace Soari.WinService.Srvs
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Integration()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
