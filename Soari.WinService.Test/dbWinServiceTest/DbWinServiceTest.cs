﻿// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the DbWin Service Test type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Test.dbWinServiceTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using ServiceModel.BussinesLogic.General;
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
			string Mail = "sarcpruebas@gmail.com";
			string mailTo = "luko.luis12@gmail.com";
			string mailPassword = "sarcpruebas1.";

			SmtpClient ServidorCorreo = new SmtpClient();
			msg.From = new MailAddress(Mail);
			msg.Sender = new MailAddress(Mail, "Me");
			msg.To.Add(new MailAddress(mailTo));
			msg.Subject = "Hola";
			msg.Priority = MailPriority.High;
			msg.IsBodyHtml = true;
			msg.Body = "Hola";

			ServidorCorreo.Host = "smtp.gmail.com";
			ServidorCorreo.EnableSsl = true;
			ServidorCorreo.UseDefaultCredentials = true;
			ServidorCorreo.Credentials = new NetworkCredential(Mail, mailPassword);
			ServidorCorreo.Port = 25;
			ServidorCorreo.Send(msg);
			msg.Dispose();
		}

		/// <summary>
		/// Aeses the manager test.
		/// </summary>
		[TestMethod]
		public void AesManagerTest()
		{
			AesManager msg = new AesManager();

			string EncryptedText = msg.Encrypt("contraseña");
			string DecryptedText = msg.Decrypt(EncryptedText);

			if (string.IsNullOrEmpty(EncryptedText) || string.IsNullOrEmpty(DecryptedText))
				Assert.Inconclusive();
		}
		#endregion
	}
}
