using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Partial
{
	public class GetLastSyncPartial
	{
		/// <summary>
		/// Gets or sets the execution id.
		/// </summary>
		public Guid ExecutionId { get; set; }

		/// <summary>
		/// Gets or sets the sync type.
		/// </summary>
		public string SyncType { get; set; }

		/// <summary>
		/// Gets or sets the last execution.
		/// </summary>
		public DateTime LastExecution { get; set; }
	}
}
