// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the DbWin Service Test type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Test.dbWinServiceTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using ServiceModel.Facade;
	using System.Linq;

	/// <summary>
	/// the win service test
	/// </summary>
	[TestClass]
	public class DbWinServiceTest
	{
		#region ClientConfiguration		
		/// <summary>
		/// Gets the client configuration by identifier test.
		/// </summary>
		[TestMethod]
		public void GetClientConfigurationByIdTest()
		{
			DbServiceFacade objFac = new DbServiceFacade();

			var data = objFac.ClientConfigurationById("0001");

			if (data == null)
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the client configuration by identifier test.
		/// </summary>
		[TestMethod]
		public void GetClientConfigurationByNameTest()
		{
			DbServiceFacade objFac = new DbServiceFacade();

			var data = objFac.ClientConfigurationByClientName("Fermad");

			if (data == null)
				Assert.Inconclusive();
		}
		#endregion
	}
}
