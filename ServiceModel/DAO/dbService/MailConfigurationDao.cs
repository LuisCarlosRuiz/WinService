// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the MailConfiguration type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.DAO.dbService
{
	using ServiceModel.Entities.dbService;
	using System.Linq;

	/// <summary>
	/// the mail configuration data access
	/// </summary>
	internal class MailConfigurationDao
	{
		/// <summary>
		/// Mails the configuration.
		/// </summary>
		/// <returns></returns>
		public MailConfiguration MailConfiguration()
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.MailConfiguration.Where(q => q.State == "A").FirstOrDefault();
			}
		}
	}
}
