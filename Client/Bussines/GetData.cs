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
	}
}
