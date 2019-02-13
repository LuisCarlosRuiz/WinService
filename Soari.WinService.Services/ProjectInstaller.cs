// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the ProjectInstaller type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Services
{
	using System.ServiceProcess;

	/// <summary>
	/// the project instaler
	/// </summary>
	/// <seealso cref="System.ServiceProcess.ServiceBase" />
	partial class ProjectInstaller : System.Configuration.Install.Installer
	{
		public ProjectInstaller()
		{
			InitializeComponent();
		}

		private void serviceProcessInstaller1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
		{

		}

		private void serviceInstaller1_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
		{

		}
	}
}
