using Client.Bussines;
using Client.Partial;
using Client.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
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

		#region Test Methods
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

		/// <summary>
		/// Gets the credito test.
		/// </summary>
		[TestMethod]
		public void GetCreditoTest()
		{
			var data = obj.GetCredito(new FiltroProducto()
			{
				ClaveEntidad = dbServicePassword,
				SaldosMayores = 500000
			});

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the ahorro contractual test.
		/// </summary>
		[TestMethod]
		public void GetAhorroContractualTest()
		{
			var data = obj.GetAhorroContractual(new FiltroProducto()
			{
				ClaveEntidad = dbServicePassword,
				SaldosMayores = 500000
			});

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the ahorro termino test.
		/// </summary>
		[TestMethod]
		public void GetAhorroTerminoTest()
		{
			var data = obj.GetAhorroTermino(new FiltroProducto()
			{
				ClaveEntidad = dbServicePassword,
				SaldosMayores = 500000
			});

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the ahorro vista test.
		/// </summary>
		[TestMethod]
		public void GetAhorroVistaTest()
		{
			var data = obj.GetAhorroVista(new FiltroProducto()
			{
				ClaveEntidad = dbServicePassword,
				SaldosMayores = 500000
			});

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the aporte test.
		/// </summary>
		[TestMethod]
		public void GetAporteTest()
		{
			var data = obj.GetAporte(new FiltroProducto()
			{
				ClaveEntidad = dbServicePassword,
				SaldosMayores = 500000
			});

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the balance test.
		/// </summary>
		[TestMethod]
		public void GetBalanceTest()
		{
			string[] cuentas = new string[] {
						"1",
						"11",
						"1105",
						"110505"
					};

			var data = obj.GetBalance(new FiltroBalance()
			{
				ClaveEntidad = dbServicePassword,
				SaldosMayores = 500000,
				Anio = 2018,
				Mes = 05,
				CodigoCuentas = cuentas
			});

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the balance agencia test.
		/// </summary>
		[TestMethod]
		public void GetBalanceAgenciaTest()
		{
			string[] cuentas = new string[] {
						"1",
						"11",
						"1105",
						"110505"
					};

			var data = obj.GetBalanceAgencia(new FiltroBalance()
			{
				ClaveEntidad = dbServicePassword,
				SaldosMayores = 500000,
				Anio = 2018,
				Mes = 05,
				CodigoCuentas = cuentas
			});

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the novedades test.
		/// </summary>
		[TestMethod]
		public void GetNovedadesTest()
		{
			var data = obj.GetNovedades(new FiltroProducto()
			{
				ClaveEntidad = dbServicePassword,
				SaldosMayores = 500000
			});

			if (!data.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the transacciones test.
		/// </summary>
		[TestMethod]
		public void GetTransaccionesTest()
		{
			var data = obj.GetTransacciones(new FiltroTransacciones()
			{
				ClaveEntidad = dbServicePassword,
				MovimientosDesde = DateTime.Parse("2018/01/01"),
				MovimientosHasta = DateTime.Parse("2018/05/05")
			});

			if (!data.Any())
				Assert.Inconclusive();
		}
		#endregion

		/// <summary>
		/// Gets the service method test.
		/// </summary>
		[TestMethod]
		public void GetServiceMethodTest()
		{
			Global obj = new Global();

			var methodList = obj.GetServiceAtributes().Where(q => !q.Name.Contains("Async"));
			List<string> methodNames = new List<string>();

			foreach (var item in methodList)
			{
				methodNames.Add(item.Name);
			}

			if (!methodNames.Any())
				Assert.Inconclusive();
		}
	}
}
