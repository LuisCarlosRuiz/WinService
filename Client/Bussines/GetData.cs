using Client.Partial;
using Client.SoapiClient;

namespace Client.Bussines
{
	public class GetData : SoapiConection
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GetData"/> class.
		/// </summary>
		/// <param name="_Url">The URL.</param>
		/// <param name="_User">The user.</param>
		/// <param name="_Password">The password.</param>
		public GetData(string _Url, string _User, string _Password)
		{
			if (string.IsNullOrEmpty(_Url) && string.IsNullOrEmpty(_User))
				return;

			Url = _Url;
			User = _User;
			Password = _Password;
		}

		/// <summary>
		/// Gets the last sync method.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public ExecutionControl[] GetLastSync(Partial.FiltroBase filtro)
		{
			var data = Client().GetLastSync(new SoapiClient.FiltroBase() {
				ClaveEntidad = filtro.ClaveEntidad
			});

			return data;
		}

		/// <summary>
		/// Gets the asociado.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public AsociadoSOARIPartial[] GetAsociado(Partial.FiltroAsociado filtro)
		{
			var data = Client().ObtenerAsociado(new SoapiClient.FiltroAsociado()
			{				
				ClaveEntidad = filtro.ClaveEntidad,
				DesdeFechaIngreso = filtro.DesdeFechaIngreso
			});

			return data;
		}

		/// <summary>
		/// Gets the credito.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public CreditoSOARIPartial[] GetCredito(Partial.FiltroProducto filtro)
		{
			var data = Client().ObtenerCreditos(new SoapiClient.FiltroProducto()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				SaldosMayores = filtro.SaldosMayores
			});

			return data;
		}

		/// <summary>
		/// Gets the ahorro contractual.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public AhorroContractualSOARIPartial[] GetAhorroContractual(Partial.FiltroProducto filtro)
		{
			var data = Client().ObtenerAhorroContractual(new SoapiClient.FiltroProducto()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				SaldosMayores = filtro.SaldosMayores
			});

			return data;
		}

		/// <summary>
		/// Gets the ahorro termino.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public AhorroTerminoSOARIPartial[] GetAhorroTermino(Partial.FiltroProducto filtro)
		{
			var data = Client().ObtenerAhorroTermino(new SoapiClient.FiltroProducto()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				SaldosMayores = filtro.SaldosMayores
			});

			return data;
		}

		/// <summary>
		/// Gets the ahorro vista.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public AhorroVistaSOARIPartial[] GetAhorroVista(Partial.FiltroProducto filtro)
		{
			var data = Client().ObtenerAhorroVista(new SoapiClient.FiltroProducto()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				SaldosMayores = filtro.SaldosMayores
			});

			return data;
		}

		/// <summary>
		/// Gets the aporte.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public AporteSOARIPartial[] GetAporte(Partial.FiltroProducto filtro)
		{
			var data = Client().ObtenerAporte(new SoapiClient.FiltroProducto()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				SaldosMayores = filtro.SaldosMayores
			});

			return data;
		}

		/// <summary>
		/// Gets the balance.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public BalanceSOARIPartial[] GetBalance(Partial.FiltroBalance filtro)
		{
			var data = Client().ObtenerBalance(new SoapiClient.FiltroBalance()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				SaldosMayores = filtro.SaldosMayores,
				Anio = filtro.Anio,
				Mes = filtro.Mes,
				CodigoCuentas = filtro.CodigoCuentas
			});

			return data;
		}

		/// <summary>
		/// Gets the balance agencia.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public BalanceAgenciaSOARIPartial[] GetBalanceAgencia(Partial.FiltroBalance filtro)
		{
			var data = Client().ObtenerBalanceAgencia(new SoapiClient.FiltroBalance()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				SaldosMayores = filtro.SaldosMayores,
				Anio = filtro.Anio,
				Mes = filtro.Mes,
				CodigoCuentas = filtro.CodigoCuentas
			});

			return data;
		}

		/// <summary>
		/// Gets the novedades.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public NovedadesSOARIPartial[] GetNovedades(Partial.FiltroProducto filtro)
		{
			var data = Client().ObtenerNovedades(new SoapiClient.FiltroProducto()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				SaldosMayores = filtro.SaldosMayores
			});

			return data;
		}

		/// <summary>
		/// Gets the transacciones.
		/// </summary>
		/// <param name="filtro">The filtro.</param>
		/// <returns></returns>
		public TransaccionesSOARIPartial[] GetTransacciones(Partial.FiltroTransacciones filtro)
		{
			var data = Client().ObtenerTransacciones(new SoapiClient.FiltroTransacciones()
			{
				ClaveEntidad = filtro.ClaveEntidad,
				MovimientosDesde = filtro.MovimientosDesde,
				MovimientosHasta = filtro.MovimientosHasta
			});

			return data;
		}
	}
}
