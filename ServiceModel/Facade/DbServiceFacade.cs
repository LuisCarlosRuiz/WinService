// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the data base service facade type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Facade
{
	using ServiceModel.BussinesLogic.dbService;
	using ServiceModel.Entities.dbService;

	/// <summary>
	/// the data base service facade
	/// </summary>
	public class DbServiceFacade
	{
		#region ClientConfiguration
		/// <summary>
		/// Clients the configuration by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns></returns>
		public ClientConfiguration ClientConfigurationById(string id)
		{
			return new ClientConfigurationBL().ClientConfigurationById(id);
		}

		/// <summary>
		/// Clients the name of the configuration by client.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public ClientConfiguration ClientConfigurationByClientName(string name)
		{
			return new ClientConfigurationBL().ClientConfigurationByClientName(name);
		}
		#endregion
	}
}
