// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the DbWin Service Test type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Test.dbWinServiceTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using ServiceModel.Facade;
	using System.Linq;
	using System.Net;
	using System.Net.Mail;

	/// <summary>
	/// the win service test
	/// </summary>
	[TestClass]
	public class DbWinServiceTest
	{
		#region ClientConfiguration		
		/// <summary>
		/// Gets the client configuration by identifier test.
		/// </summary>
		[TestMethod]
		public void GetClientConfigurationByIdTest()
		{
			DbServiceFacade objFac = new DbServiceFacade();

			var data = objFac.ClientConfigurationById("0001");

			if (data == null)
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the client configuration by identifier test.
		/// </summary>
		[TestMethod]
		public void GetClientConfigurationByNameTest()
		{
			DbServiceFacade objFac = new DbServiceFacade();

			var data = objFac.ClientConfigurationByClientName("Fermad");

			if (data == null)
				Assert.Inconclusive();
		}

		/// <summary>
		/// Mails the test.
		/// </summary>
		[TestMethod]
		public void MailTest()
		{
			MailMessage msg = new MailMessage();
			string Mail = "net.programador1@gmail.com";
			string mailTo = "luko.luis12@gmail.com";
			string mailPassword = "Opa4*5as1,";

			SmtpClient ServidorCorreo = new SmtpClient();
			msg.From = new MailAddress(Mail);
			msg.Sender = new MailAddress(Mail, "Me");
			msg.To.Add(new MailAddress(mailTo));
			msg.Subject = "Hola";
			msg.Priority = MailPriority.High;
			msg.IsBodyHtml = true;
			msg.Body = "Hola";

			ServidorCorreo.Host = "smtp.gmail.com";
			ServidorCorreo.EnableSsl = false;
			ServidorCorreo.UseDefaultCredentials = false;
			ServidorCorreo.Credentials = new NetworkCredential(Mail, mailPassword);
			ServidorCorreo.Port = 25;
			ServidorCorreo.Send(msg);
			msg.Dispose();
		}
		#endregion
	}
}
