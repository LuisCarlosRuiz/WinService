// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Client Configuration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Client Configuration
	/// </summary>
	[Table("ClientConfiguration")]
	public class ClientConfiguration
	{
		/// <summary>
		/// Gets or sets the configuration identifier.
		/// </summary>
		/// <value>
		/// The configuration identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ConfigurationId")]
		public Guid ConfigurationId { get; set; }

		/// <summary>
		/// Gets or sets the job identifier.
		/// </summary>
		/// <value>
		/// The job identifier.
		/// </value>
		[Column("JobId", TypeName = "varchar")]
		[MaxLength(4)]
		public string JobId { get; set; }

		/// <summary>
		/// Gets or sets the name of the database server.
		/// </summary>
		/// <value>
		/// The name of the database server.
		/// </value>
		[Column("DBServerName", TypeName = "varchar")]
		[MaxLength(100)]
		public string DBServerName { get; set; }

		/// <summary>
		/// Gets or sets the name of the database.
		/// </summary>
		/// <value>
		/// The name of the database.
		/// </value>
		[Column("DBName", TypeName = "varchar")]
		[MaxLength(50)]
		public string DBName { get; set; }

		/// <summary>
		/// Gets or sets the database user.
		/// </summary>
		/// <value>
		/// The database user.
		/// </value>
		[Column("DBUser", TypeName = "varchar")]
		[MaxLength(50)]
		public string DBUser { get; set; }

		/// <summary>
		/// Gets or sets the database password.
		/// </summary>
		/// <value>
		/// The database password.
		/// </value>
		[Column("DBPassword", TypeName = "varchar")]
		[MaxLength(20)]
		public string DBPassword { get; set; }

		/// <summary>
		/// Gets or sets the service URL.
		/// </summary>
		/// <value>
		/// The service URL.
		/// </value>
		[Column("ServiceUrl", TypeName = "varchar")]
		[MaxLength(200)]
		public string ServiceUrl { get; set; }

		/// <summary>
		/// Gets or sets the service user.
		/// </summary>
		/// <value>
		/// The service user.
		/// </value>
		[Column("ServiceUser", TypeName = "varchar")]
		[MaxLength(20)]
		public string ServiceUser { get; set; }

		/// <summary>
		/// Gets or sets the service password.
		/// </summary>
		/// <value>
		/// The service password.
		/// </value>
		[Column("ServicePassword", TypeName = "varchar")]
		[MaxLength(20)]
		public string ServicePassword { get; set; }

		/// <summary>
		/// Gets or sets the servicedb password.
		/// </summary>
		/// <value>
		/// The servicedb password.
		/// </value>
		[Column("ServicedbPassword", TypeName = "varchar")]
		[MaxLength(20)]
		public string ServicedbPassword { get; set; }

		/// <summary>
		/// Gets or sets the name of the client.
		/// </summary>
		/// <value>
		/// The name of the client.
		/// </value>
		[Column("ClientName", TypeName = "varchar")]
		[MaxLength(100)]
		public string ClientName { get; set; }

		/// <summary>
		/// Gets or sets the state.
		/// </summary>
		/// <value>
		/// The state.
		/// </value>
		[Column("State", TypeName = "varchar")]
		[MaxLength(10)]
		public string State { get; set; }
	}
}
