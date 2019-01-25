// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the MailManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.BussinesLogic.General
{
	using ServiceModel.Entities.dbService;
	using ServiceModel.BussinesLogic.dbService;
	using System.Net.Mail;
	using System;
	using System.Net;

	/// <summary>
	/// the mail manager
	/// </summary>
	public class MailManager
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MailManager"/> class.
		/// </summary>
		/// <param name="mail">The mail.</param>
		public MailManager()
		{

		}

		/// <summary>
		/// Gets the mail by state active.
		/// </summary>
		/// <returns></returns>
		private MailConfiguration GetMailByStateActive()
		{
			return new MailConfigurationBL().MailConfiguration();
		}

		/// <summary>
		/// Sends the mail by default.
		/// </summary>
		/// <param name="header">The header.</param>
		/// <param name="body">The body.</param>
		/// <param name="mailTo">The mail to.</param>
		public void SendMailByDefault(string header, string body, string mailTo)
		{
			var Mail = GetMailByStateActive();

			using (var msg = new MailMessage())
			{
				using (var ServidorCorreo = new SmtpClient())
				{
					msg.From = new MailAddress(Mail.Mail);
					msg.Sender = new MailAddress(Mail.Mail, "Me");
					msg.To.Add(new MailAddress(mailTo));
					msg.Subject = header;
					msg.Priority = MailPriority.High;
					msg.IsBodyHtml = true;
					msg.Body = body;

					ServidorCorreo.Host = Mail.Host;
					ServidorCorreo.EnableSsl = Mail.UseCredentials == 1;
					ServidorCorreo.UseDefaultCredentials = Mail.UseCredentials == 1;
					ServidorCorreo.Credentials = new NetworkCredential(Mail.Mail, Mail.Password);
					ServidorCorreo.Port = Mail.Port;
					ServidorCorreo.Send(msg);
					msg.Dispose();
				}

			}
		}

		internal void MailBuilder(string message, ExecutionControl executionControl, UserAdmin user)
		{
			string header = $"[Importante] Mensaje de Soari.WinService - {message}";
			string body = $@"<b>Hola {user.Name}</b>.
							<br/><br/>
							Soari.WinService tiene un mensaje importante para usted con el siguiente titulo: <b>{message}</b>
							<br/><br/>
							Id: {executionControl.ExecutionId}<br/>
							Fecha: {executionControl.ExecutionDate}<br/>
							Cliente: {executionControl.Client}<br/>
							Tarea: {executionControl.Task}<br/>
							Mensaje: <br/>
							{executionControl.Log}
							<br/><br/>
							Este correo es solo de salido, no responder.";

			SendMailByDefault(header, body, user.Mail);
		}
	}
}
