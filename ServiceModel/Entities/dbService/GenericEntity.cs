using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Entities.dbService
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Data.Entity;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	using EntityFramework.BulkInsert.Extensions;

	/// <summary>
	/// the generic entity for db Win context
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	public class GenericEntity<TEntity> where TEntity : class
	{
		private readonly DbSet<TEntity> dbSet;
		private DbContext context;

		/// <summary>
		/// Initializes a new instance of the <see cref="GenericEntity{TEntity}"/> class.
		/// </summary>
		/// <param name="ctx">The CTX.</param>
		public GenericEntity(DbContext ctx)
		{
			dbSet = ctx.Set<TEntity>();
			this.context = ctx;
		}

		/// <summary>
		/// The update entity.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void UpdateEntity(TEntity entity)
		{
			this.dbSet.Attach(entity);
			this.context.Entry(entity).State = EntityState.Modified;
		}

		/// <summary>
		/// The truncate.
		/// </summary>
		public void Truncate()
		{
			this.context.Database.ExecuteSqlCommand($"Truncate Table {typeof(TEntity).GetCustomAttribute<TableAttribute>(false).Name}");
		}

		/// <summary>
		/// The bulk insert.
		/// </summary>
		/// <param name="entities">
		/// The entities.
		/// </param>
		public void BulkInsert(IEnumerable<TEntity> entities)
		{
			try
			{
				this.context.BulkInsert<TEntity>(entities);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.ToString());
			}
		}

		/// <summary>
		/// The get entity.
		/// </summary>
		/// <param name="orderBy">
		/// The order by.
		/// </param>
		/// <param name="take">
		/// The take.
		/// </param>
		/// <param name="skip">
		/// The skip.
		/// </param>
		/// <returns>
		/// The <see cref="IQueryable"/>.
		/// </returns>
		public IQueryable<TEntity> GetEntity(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, int take, int skip)
		{
			return orderBy.Invoke(this.dbSet).Skip(skip).Take(take).AsQueryable();
		}

		/// <summary>
		/// The get entity.
		/// </summary>
		/// <param name="filter">
		/// The filter.
		/// </param>
		/// <param name="orderBy">
		/// The order by.
		/// </param>
		/// <param name="take">
		/// The take.
		/// </param>
		/// <param name="skip">
		/// The skip.
		/// </param>
		/// <param name="include">
		/// The include.
		/// </param>
		/// <returns>
		/// The <see cref="IQueryable"/>.
		/// </returns>
		public IQueryable<TEntity> GetEntity(
			Expression<Func<TEntity, bool>> filter,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			int take,
			int skip,
			string include)
		{
			IQueryable<TEntity> query = this.dbSet;

			query = query.Where(filter);

			foreach (var includeProperty in include.Split(
				new char[] { ',' },
				StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			return orderBy.Invoke(query).Skip(skip).Take(take).AsQueryable();
		}

		/// <summary>
		/// The get entity.
		/// </summary>
		/// <param name="filter">
		/// The filter.
		/// </param>
		/// <param name="orderBy">
		/// The order by.
		/// </param>
		/// <param name="take">
		/// The take.
		/// </param>
		/// <param name="skip">
		/// The skip.
		/// </param>
		/// <returns>
		/// The <see cref="IQueryable"/>.
		/// </returns>
		public IQueryable<TEntity> GetEntity(
			Expression<Func<TEntity, bool>> filter,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			int take,
			int skip)
		{
			IQueryable<TEntity> query = this.dbSet;

			query = query.Where(filter);

			return orderBy.Invoke(query).Skip(skip).Take(take).AsQueryable();
		}

		/// <summary>
		/// The get entity.
		/// </summary>
		/// <param name="filter">
		/// The filter.
		/// </param>
		/// <returns>
		/// The <see cref="TEntity"/>.
		/// </returns>
		public IQueryable<TEntity> GetEntity(Expression<Func<TEntity, bool>> filter)
		{
			IQueryable<TEntity> query = this.dbSet;

			query = query.Where(filter);

			return query.AsQueryable();
		}

		/// <summary>
		/// The get entity.
		/// </summary>
		/// <param name="orderBy">
		/// The order by.
		/// </param>
		/// <param name="take">
		/// The take.
		/// </param>
		/// <param name="skip">
		/// The skip.
		/// </param>
		/// <param name="include">
		/// The include.
		/// </param>
		/// <returns>
		/// The <see cref="IQueryable"/>.
		/// </returns>
		public IQueryable<TEntity> GetEntity(
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
			int take,
			int skip,
			string include)
		{
			IQueryable<TEntity> query = this.dbSet;

			foreach (var includeProperty in include.Split(
				new char[] { ',' },
				StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			return orderBy.Invoke(query).Skip(skip).Take(take).AsQueryable();
		}

		/// <summary>
		/// The get entity.
		/// </summary>
		/// <param name="include">
		/// The include.
		/// </param>
		/// <returns>
		/// The <see cref="IQueryable"/>.
		/// </returns>
		public IQueryable<TEntity> GetEntity(string include)
		{
			IQueryable<TEntity> query = this.dbSet;

			foreach (var includeProperty in include.Split(
				new char[] { ',' },
				StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			return query.AsQueryable();
		}

		/// <summary>
		/// The get entity.
		/// </summary>
		/// <returns>
		/// The <see cref="IQueryable"/>.
		/// </returns>
		public IQueryable<TEntity> GetEntity()
		{
			return this.dbSet.AsQueryable();
		}

		/// <summary>
		/// The insert entity.
		/// </summary>
		/// <param name="entity">
		/// The entity.
		/// </param>
		public void InsertEntity(TEntity entity)
		{
			this.dbSet.Add(entity);
		}
	}
}
