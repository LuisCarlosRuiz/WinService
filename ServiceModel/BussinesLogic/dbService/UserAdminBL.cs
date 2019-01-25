// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the UserAdminDao type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.BussinesLogic.dbService
{
	using ServiceModel.DAO.dbService;
	using ServiceModel.Entities.dbService;
	using System.Collections.Generic;

	/// <summary>
	/// the user admin Bussines logic
	/// </summary>
	internal class UserAdminBL
	{
		/// <summary>
		/// Gets the list user admin by state active.
		/// </summary>
		/// <returns></returns>
		public List<UserAdmin> GetListUserAdminByStateActive()
		{
			return new UserAdminDao().GetListUserAdminByStateActive();
		}
	}
}
