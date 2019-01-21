using Client.Bussines;
using Client.Partial;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Soari.WinService.Test.ClientTest
{
	/// <summary>
	/// the client test
	/// </summary>
	[TestClass]
	public class ClientTest
	{
		private string dbServicePassword;
		private GetData obj;

		public ClientTest()
		{
			dbServicePassword = "opa123.";
			obj = new GetData("https://riskmanagerintegration.test.local/SOARI.svc?wsdl"
									, "OmeOme"
									, "opa123.");
		}

		/// <summary>
		/// Clients the conection test.
		/// </summary>
		[TestMethod]
		public void ClientConectionTest()
		{			
			var data = obj.GetLastSync(new FiltroBase()
						{ ClaveEntidad = dbServicePassword });

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Clients the conection test.
		/// </summary>
		[TestMethod]
		public void GetAsociadoTest()
		{
			var data = obj.GetAsociado(new FiltroAsociado()
			{
				ClaveEntidad = dbServicePassword,
				DesdeFechaIngreso = DateTime.Parse("2018/05/01")
			});

			if (!data.Any())
				Assert.Inconclusive();
		}
	}
}
