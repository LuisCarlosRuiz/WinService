﻿using System.ComponentModel;
using System.Configuration.Install;

namespace Soari.WinService.Srvs
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

		private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
		{

		}

		private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
		{

		}
	}
}
