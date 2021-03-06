﻿// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Deal type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.ConectionEngine
{
	using ServiceModel.Entities.dbService;
	using ServiceModel.Entities.Soari;
	using ServiceModel.BussinesLogic.General;
	using System;
	using System.Linq;

	/// <summary>
	/// The  distributor of connections to database
	/// </summary>
	public class Deal
	{
		private string IdCliente;

		/// <summary>
		/// Initializes a new instance of the <see cref="Deal"/> class.
		/// </summary>
		/// <param name="_IdCliente">The identifier cliente.</param>
		public Deal(string _IdCliente)
		{
			if (string.IsNullOrEmpty(_IdCliente))
				return;
			IdCliente = _IdCliente;
		}

		/// <summary>
		/// Connections the string.
		/// </summary>
		/// <returns></returns>
		private string ConnectionString()
		{
			ClientConfiguration objConfiguration;

			using (var ctx = new DbServiceContext())
			{
				objConfiguration = ctx.ClientConfiguration.Where(q => q.JobId == IdCliente).FirstOrDefault();
			}

			if (!ValidarConexion(objConfiguration))
				throw new NullReferenceException("50003 - Hacen falta parametros para conectar a la base de datos");

			string DataBasePss = new AesManager().Decrypt(objConfiguration.DBPassword);

			return $@"Data Source={objConfiguration.DBServerName};
					Initial Catalog={objConfiguration.DBName};
					Persist Security Info=True;
					User ID={objConfiguration.DBUser};
					Password={DataBasePss}";
		}

		/// <summary>
		/// Validars the conexion.
		/// </summary>
		/// <param name="objConfiguration">The object configuration.</param>
		/// <returns></returns>
		private bool ValidarConexion(ClientConfiguration objConfiguration)
		{
			if (objConfiguration != null && objConfiguration.State == "A")
				if (!string.IsNullOrEmpty(objConfiguration.DBServerName)
					&& !string.IsNullOrEmpty(objConfiguration.DBName)
					&& !string.IsNullOrEmpty(objConfiguration.DBUser)
					&& !string.IsNullOrEmpty(objConfiguration.DBPassword))
					return true;
				else
					return false;
			else
				return false;
		}

		/// <summary>
		/// Databases the soary context.
		/// </summary>
		/// <returns></returns>
		public SoaryContext DbSoaryContext()
		{
			return new SoaryContext(ConnectionString());
		}
	}
}
