// --------------------------------------------------------------------------------------------------------------------
// Luis Carlos Ruiz 
// <summary>
//   Defines the DbSoari Test type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Soari.WinService.Test.SoariModelTest
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using ServiceModel.Entities.ConectionEngine;
	using ServiceModel.Entities.dbService;
	using ServiceModel.Entities.Soari;
	using ServiceModel.Facade;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	/// The soari DbSoari Test
	/// </summary>
	[TestClass]
	public class DbSoariTest
	{
		/// <summary>
		/// Gets the nits from diferent database test.
		/// </summary>
		[TestMethod]
		public void GetNitsFromDiferentDBTest()
		{
			SoariFacade objFac1 = new SoariFacade("0001");
			SoariFacade objFac2 = new SoariFacade("0002");
			SoariFacade objFac3 = new SoariFacade("0003");

			var lstNit1 = objFac1.GetNit();
			var lstNit2 = objFac2.GetNit();
			var lstNit3 = objFac3.GetNit();

			if (!lstNit1.Any() || !lstNit2.Any() || !lstNit3.Any())
				Assert.Inconclusive();
		}

		/// <summary>
		/// Gets the nit test.
		/// </summary>
		[TestMethod]
		public void GetNitTest()
		{
			List<Nit> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<Nit>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.numNit)
							, 1000, 0,
							@"Agencia, Pais
							, Departamento , Ciudad , Genero
							, TipoContrato , NivelEstudio , EstadoCivil
							, Ocupacion , SectorEconomico , JornadaLaboral
							, ActividadEconomica, TipoIdentificacion"
							).ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}

		/// <summary>
		/// Gets the nit test.
		/// </summary>
		[TestMethod]
		public void GetCreditoTest()
		{
			List<Credito> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<Credito>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.numNit)
							, 1000, 0,
							@"Agencia, TipoGarantia
							, TipoCuota , TipoModalidad"
							).ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}

		/// <summary>
		/// Gets the contabilidad test.
		/// </summary>
		[TestMethod]
		public void GetContabilidadTest()
		{
			List<Contabilidad> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<Contabilidad>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.NumeroCuenta)
							, 1000, 0,
							@"Agencia"
							).ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}

		/// <summary>
		/// Gets the cuota extra test.
		/// </summary>
		[TestMethod]
		public void GetCuotaExtraTest()
		{
			List<CuotaExtra> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<CuotaExtra>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.Pagare)
							, 1000, 0).ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}

		/// <summary>
		/// Gets the novedad varia test.
		/// </summary>
		[TestMethod]
		public void GetNovedadVariaTest()
		{
			List<NovedadVaria> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<NovedadVaria>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.Consecutivo)
							, 1000, 0).ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}

		/// <summary>
		/// Gets the ahorro test.
		/// </summary>
		[TestMethod]
		public void GetAhorroTest()
		{
			List<Ahorro> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<Ahorro>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.dtmFechaApertura)
							, 1000, 0,
							@"TipoAhorro, Agencia, EstadoAhorro").ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}

		/// <summary>
		/// Gets the aporte test.
		/// </summary>
		[TestMethod]
		public void GetAporteTest()
		{
			List<Aporte> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<Aporte>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.dtmFechaApertura)
							, 1000, 0,
							@"Agencia, TipoAporte").ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}

		/// <summary>
		/// Gets the transacciones test.
		/// </summary>
		[TestMethod]
		public void GetTransaccionesTest()
		{
			List<Transacciones> data;

			using (var ctx = new Deal("0001").DbSoaryContext())
			{
				var repository = new GenericEntity<Transacciones>(ctx);
				data = repository.GetEntity(q => q.OrderBy(d => d.dtmFechaHora)
							, 1000, 0,
							@"Agencia, TipoProducto, TipoTransaccion, Canal").ToList();
			}

			if (!data.Any())
			{
				Assert.Inconclusive();
			}
		}
	}
}