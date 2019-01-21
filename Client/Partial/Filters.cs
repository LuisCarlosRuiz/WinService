using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Partial
{
	/// <summary>
	/// the filtro base
	/// </summary>
	public class FiltroBase
	{
		/// <summary>
		/// Gets or sets the clave entidad.
		/// </summary>
		public string ClaveEntidad { get; set; }
	}

	/// <summary>
	/// The filtro Asociado.
	/// </summary>
	public class FiltroAsociado : FiltroBase
	{
		/// <summary>
		/// Gets or sets the fecha acta.
		/// </summary>
		public DateTime DesdeFechaIngreso { get; set; }
	}

	/// <summary>
	/// The filtro balance.
	/// </summary>
	public class FiltroBalance : FiltroBase
	{
		/// <summary>
		/// Gets or sets the codigo cuentas.
		/// </summary>
		public string[] CodigoCuentas { get; set; }

		/// <summary>
		/// Gets or sets the saldos mayores.
		/// </summary>
		public long SaldosMayores { get; set; }

		/// <summary>
		/// Gets or sets the año.
		/// </summary>
		public int Anio { get; set; }

		/// <summary>
		/// Gets or sets the mes.
		/// </summary>
		public int Mes { get; set; }
	}

	/// <summary>
	/// The filtro producto.
	/// </summary>
	public class FiltroProducto : FiltroBase
	{
		/// <summary>
		/// Gets or sets the saldos mayores.
		/// </summary>
		public long SaldosMayores { get; set; }
	}

	/// <summary>
	/// The filtro transacciones.
	/// </summary>
	public class FiltroTransacciones : FiltroBase
	{
		/// <summary>
		/// Gets or sets the movimientos desde.
		/// </summary>
		public DateTime MovimientosDesde { get; set; }

		/// <summary>
		/// Gets or sets the movimientos hasta.
		/// </summary>
		public DateTime MovimientosHasta { get; set; }
	}
}
