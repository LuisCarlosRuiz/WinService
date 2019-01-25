// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the MailConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.BussinesLogic.dbService
{
	using ServiceModel.Entities.dbService;
	using ServiceModel.DAO.dbService;
	/// <summary>
	/// The mail configuration Bussines logic
	/// </summary>
	internal class MailConfigurationBL
	{
		/// <summary>
		/// Mails the configuration.
		/// </summary>
		/// <returns></returns>
		public MailConfiguration MailConfiguration()
		{
			return new MailConfigurationDao().MailConfiguration();
		}
	}
}
