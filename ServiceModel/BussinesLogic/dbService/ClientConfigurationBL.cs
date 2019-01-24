// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Client Configuration BL type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.BussinesLogic.dbService
{
	using ServiceModel.DAO.WinService;
	using ServiceModel.Entities.dbService;

	/// <summary>
	/// the Client configuration bussines logic
	/// </summary>
	internal class ClientConfigurationBL
	{
		/// <summary>
		/// Clients the configuration by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public ClientConfiguration ClientConfigurationById(string id)
		{
			return new ClientConfigurationDao().ClientConfigurationById(id);
		}

		/// <summary>
		/// Clients the name of the configuration by client.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public ClientConfiguration ClientConfigurationByClientName(string name)
		{
			return new ClientConfigurationDao().ClientConfigurationByClientName(name);
		}
	}
}
