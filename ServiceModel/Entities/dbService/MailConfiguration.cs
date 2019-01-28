// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the MailConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// The mail configuration
	/// </summary>
	[Table("MailConfiguration")]
	public class MailConfiguration
	{
		/// <summary>
		/// Gets or sets the mail identifier.
		/// </summary>
		/// <value>
		/// The mail identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CuentaId")]
		public Guid MailId { get; set; }

		/// <summary>
		/// Gets or sets the server.
		/// </summary>
		/// <value>
		/// The server.
		/// </value>
		[Column("Host", TypeName = "varchar")]
		[MaxLength(50)]
		public string Host { get; set; }

		/// <summary>
		/// Gets or sets the port.
		/// </summary>
		/// <value>
		/// The port.
		/// </value>
		[Column("Port", TypeName = "int")]
		public int Port { get; set; }

		/// <summary>
		/// Gets or sets the use credencials.
		/// </summary>
		/// <value>
		/// The use credencials.
		/// </value>
		[Column("UseCredencials", TypeName = "tinyint")]
		public byte UseCredentials { get; set; }

		/// <summary>
		/// Gets or sets the enable SSL.
		/// </summary>
		/// <value>
		/// The enable SSL.
		/// </value>
		[Column("EnableSsl", TypeName = "tinyint")]
		public byte EnableSsl { get; set; }

		/// <summary>
		/// Gets or sets the mail.
		/// </summary>
		/// <value>
		/// The mail.
		/// </value>
		[Column("Mail", TypeName = "varchar")]
		[MaxLength(100)]
		public string Mail { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		/// <value>
		/// The password.
		/// </value>
		[Column("Password", TypeName = "varchar")]
		[MaxLength(200)]
		public string Password { get; set; }

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		[Column("State", TypeName = "char")]
		[MaxLength(1)]
		public string State { get; set; }
	}
}
