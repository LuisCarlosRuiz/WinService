// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Scheduler type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Scheduler
	/// </summary>
	[Table("Scheduler")]
	public class Scheduler
	{
		/// <summary>
		/// Gets or sets the configuration identifier.
		/// </summary>
		/// <value>
		/// The configuration identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("SchedulerId")]
		public Guid SchedulerId { get; set; }

		/// <summary>
		/// Gets or sets the concecutivo.
		/// </summary>
		/// <value>
		/// The concecutivo.
		/// </value>
		[Column("Consecutive", TypeName = "int")]
		public int Consecutive { get; set; }

		/// <summary>
		/// Gets or sets the name of the task.
		/// </summary>
		/// <value>
		/// The name of the task.
		/// </value>
		[Column("TaskName", TypeName = "varchar")]
		[MaxLength(150)]
		public string TaskName { get; set; }

		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		/// <value>
		/// The client identifier.
		/// </value>
		[Column("ClientId", TypeName = "varchar")]
		[MaxLength(5)]
		public string ClientId { get; set; }

		/// <summary>
		/// Gets or sets the status.
		/// </summary>
		/// <value>
		/// The status.
		/// </value>
		[Column("Status", TypeName = "char")]
		[MaxLength(1)]
		public string Status { get; set; }
	}
}
