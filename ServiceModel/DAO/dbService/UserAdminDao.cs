// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the UserAdminDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.DAO.dbService
{
	using ServiceModel.Entities.dbService;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// the user admin data access
	/// </summary>
	internal class UserAdminDao
	{
		/// <summary>
		/// Gets the list user admin by state active.
		/// </summary>
		/// <returns></returns>
		public List<UserAdmin> GetListUserAdminByStateActive()
		{
			using (var ctx = new DbServiceContext())
			{
				return ctx.UserAdmin.Where(q => q.State == "A").ToList();
			}
		}
	}
}
