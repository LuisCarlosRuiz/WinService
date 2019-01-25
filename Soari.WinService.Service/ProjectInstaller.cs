// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the ProjectInstaller type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Service
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
	}
}
