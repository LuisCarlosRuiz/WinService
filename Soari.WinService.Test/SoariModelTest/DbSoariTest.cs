// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the DbSoari Test type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Test.SoariModelTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using ServiceModel.Facade;
	using System.Linq;

	/// <summary>
	/// The soari DbSoari Test
	/// </summary>
	[TestClass]
	public class DbSoariTest
	{
		/// <summary>
		/// Databases the context test.
		/// </summary>
		[TestMethod]
		public void GetNitsTest()
		{
			SoariFacade objFac = new SoariFacade("0002");

			var lstNit = objFac.GetNit();

			if (!lstNit.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the nits from diferent database test.
		/// </summary>
		[TestMethod]
		public void GetNitsFromDiferentDBTest()
		{
			SoariFacade objFac1 = new SoariFacade("0001");
			SoariFacade objFac2 = new SoariFacade("0002");
			SoariFacade objFac3 = new SoariFacade("0003");

			var lstNit1 = objFac1.GetNit();
			var lstNit2 = objFac2.GetNit();
			var lstNit3 = objFac3.GetNit();

			if (!lstNit1.Any() || !lstNit2.Any() || !lstNit3.Any())
				Assert.Inconclusive();
		}
	}
}
