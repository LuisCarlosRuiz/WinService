// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Execution Control type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the execution control
	/// </summary>
	[Table("ExecutionControl")]
	public class ExecutionControl
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("ExecutionId")]
		public Guid ExecutionId { get; set; }

		/// <summary>
		/// Gets or sets the execution date.
		/// </summary>
		/// <value>
		/// The execution date.
		/// </value>
		[Column("ExecutionDate", TypeName = "datetime")]
		public DateTime ExecutionDate { get; set; }

		/// <summary>
		/// Gets or sets the configuration identifier.
		/// </summary>
		/// <value>
		/// The configuration identifier.
		/// </value>
		[Column("Client", TypeName = "varchar")]
		[MaxLength(100)]
		public string Client { get; set; }

		/// <summary>
		/// Gets or sets the task.
		/// </summary>
		/// <value>
		/// The task.
		/// </value>
		[Column("Task", TypeName = "varchar")]
		[MaxLength(50)]
		public string Task { get; set; }

		/// <summary>
		/// Gets or sets the log.
		/// </summary>
		/// <value>
		/// The log.
		/// </value>
		[Column("Log", TypeName = "varchar")]
		[MaxLength(2000)]
		public string Log { get; set; }
	}
}
