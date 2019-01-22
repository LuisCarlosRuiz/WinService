// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Service Task type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	/// <summary>
	/// the Service Task
	/// </summary>
	[Table("ServiceTask")]
	public class ServiceTask
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("TaskId")]
		public Guid TaskId { get; set; }

		/// <summary>
		/// Gets or sets the name of the task.
		/// </summary>
		/// <value>
		/// The name of the task.
		/// </value>
		[Column("TaskName", TypeName = "varchar")]
		[MaxLength(50)]
		public string TaskName { get; set; }
	}
}
