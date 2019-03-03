// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the Enumerations type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ServiceModel.Entities.Partial
{

	/// <summary>
	/// the message enumeration
	/// </summary>
	public enum MessageEnum
	{
		/// <summary>
		/// The seccess
		/// </summary>
		Success,

		/// <summary>
		/// The fatal error
		/// </summary>
		FatalError
	}

	public enum ServiceTaskName
	{
		/// <summary>
		/// The task insert
		/// </summary>
		TaskInsert,

		/// <summary>
		/// The get last synchronize
		/// </summary>
		GetLastSync,

		/// <summary>
		/// The obtener creditos
		/// </summary>
		ObtenerCreditos,

		/// <summary>
		/// The obtener asociado
		/// </summary>
		ObtenerAsociado,

		/// <summary>
		/// The obtener balance
		/// </summary>
		ObtenerBalance,

		/// <summary>
		/// The obtener balance agencia
		/// </summary>
		ObtenerBalanceAgencia,

		/// <summary>
		/// The obtener ahorro contractual
		/// </summary>
		ObtenerAhorroContractual,

		/// <summary>
		/// The obtener aporte
		/// </summary>
		ObtenerAporte,

		/// <summary>
		/// The obtener ahorro termino
		/// </summary>
		ObtenerAhorroTermino,

		/// <summary>
		/// The obtener ahorro vista
		/// </summary>
		ObtenerAhorroVista,

		/// <summary>
		/// The obtener novedades
		/// </summary>
		ObtenerNovedades,

		/// <summary>
		/// The obtener transacciones
		/// </summary>
		ObtenerTransacciones
	}

	public enum TipoAhorro
	{
		/// <summary>
		/// The ahorro contractual
		/// </summary>
		AhorroContractual,

		/// <summary>
		/// The ahorro temino
		/// </summary>
		AhorroTemino,

		/// <summary>
		/// The ahorro vista
		/// </summary>
		AhorroVista,

		/// <summary>
		/// The ahorro permanente
		/// </summary>
		AhorroPermanente
	}

	public enum EstadoAporte
	{
		A = 1,
		I = 0
	}
}
