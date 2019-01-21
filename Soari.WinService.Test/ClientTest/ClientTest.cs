using Client.Bussines;
using Client.Partial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Soari.WinService.Test.ClientTest
{
	/// <summary>
	/// the client test
	/// </summary>
	[TestClass]
	public class ClientTest
	{
		/// <summary>
		/// Clients the conection test.
		/// </summary>
		[TestMethod]
		public void ClientConectionTest()
		{
			GetData obj = new GetData("https://riskmanagerintegration.test.local/SOARI.svc?wsdl"
									, "OmeOme"
									,"opa123.");
			
			var data = obj.GetLastSync(new FiltroBase()
						{ ClaveEntidad = "opa123." });


			obj.

			if (!data.Any())
				Assert.Inconclusive();
		}
	}
}
