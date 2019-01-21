using Client.Partial;
using System.Collections.Generic;

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

		public List<GetLastSyncPartial> GetLastSync(FiltroBase filtro)
		{
			var data = Client().GetLastSync(new SoapiClient.FiltroBase() {
				ClaveEntidad = filtro.ClaveEntidad
			});

			var lstGetLastSync = new List<GetLastSyncPartial>();

			foreach (var lst in data)
			{
				lstGetLastSync.Add(new GetLastSyncPartial() {
					ExecutionId = lst.ExecutionId,
					LastExecution = lst.LastExecution,
					SyncType = lst.SyncType
				});
			}

			return lstGetLastSync;
		}
	}
}
