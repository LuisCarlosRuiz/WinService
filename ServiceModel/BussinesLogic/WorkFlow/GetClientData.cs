// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the GetClientData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.BussinesLogic.WorkFlow
{
	using ServiceModel.Entities.dbService;
	using System.Linq;
	using Client.Bussines;
	using Client.SoapiClient;
	using System.Collections.Generic;
	using System;


	/// <summary>
	/// the get data servic client
	/// </summary>
	internal class GetClientData
	{
		private ClientConfiguration client;
		private List<Cuenta> cuenta;

		/// <summary>
		/// Initializes a new instance of the <see cref="GetClientData"/> class.
		/// </summary>
		/// <param name="client">The client.</param>
		/// <param name="cuenta">The cuenta.</param>
		public GetClientData(ClientConfiguration _client, List<Cuenta> _cuenta)
		{
			client = _client;
			cuenta = _cuenta;
		}

		/// <summary>
		/// Gets the balance.
		/// </summary>
		public BalanceSOARIPartial[] GetBalance()
		{
			GetData obj = new GetData(client.ServiceUrl, client.ServiceUser
									, client.ServicePassword);

			var data = obj.GetBalance(new Client.Partial.FiltroBalance()
			{
				ClaveEntidad = client.ServicedbPassword,
				SaldosMayores = long.Parse(cuenta.Select(
								q => Math.Round(q.FilterBalance.SaldosMayores)
								.ToString()).FirstOrDefault()),
				Anio = cuenta.Select(q => q.FilterBalance.Ano).FirstOrDefault(),
				Mes = cuenta.Select(q => q.FilterBalance.Mes).FirstOrDefault(),
				CodigoCuentas = cuenta.Select(q => q.CodigoCuenta).ToArray()
			});
			return data;
		}
	}
}
