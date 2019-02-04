// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the JobPartial type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Partial
{
	/// <summary>
	/// job partial
	/// </summary>
	public partial class JobPartial
	{
		/// <summary>
		/// Gets or sets the concecutivo.
		/// </summary>
		/// <value>
		/// The concecutivo.
		/// </value>
		public string Concecutivo { get; set; }

		/// <summary>
		/// Gets or sets the name of the task.
		/// </summary>
		/// <value>
		/// The name of the task.
		/// </value>
		public string TaskName { get; set; }

		/// <summary>
		/// Gets or sets the client identifier.
		/// </summary>
		/// <value>
		/// The client identifier.
		/// </value>
		public string ClientId { get; set; }

		/// <summary>
		/// Gets or sets the cron expression.
		/// </summary>
		/// <value>
		/// The cron expression.
		/// </value>
		public string CronExpression { get; set; }
	}
}
