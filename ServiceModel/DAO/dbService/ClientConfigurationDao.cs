// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the client configuration Dao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.DAO.WinService
{
	using ServiceModel.Entities.dbService;
	using System.Linq;

	/// <summary>
	/// the client configuration data access
	/// </summary>
	internal class ClientConfigurationDao
	{
		/// <summary>
		/// Clients the configuration by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public ClientConfiguration ClientConfigurationById(string id)
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.ClientConfiguration.Where(q => q.JobId == id).FirstOrDefault();
			}
		}

		/// <summary>
		/// Clients the name of the configuration by client.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public ClientConfiguration ClientConfigurationByClientName(string name)
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.ClientConfiguration.Where(q => q.ClientName == name).FirstOrDefault();
			}
		}
	}
}
