// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the ProjectInstaller type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Services
{
	using System.ComponentModel;
	using System.Configuration.Install;

	/// <summary>
	/// the project instaler
	/// </summary>
	/// <seealso cref="System.ServiceProcess.ServiceBase" />
	[RunInstaller(true)]
	partial class ProjectInstaller : Installer
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
