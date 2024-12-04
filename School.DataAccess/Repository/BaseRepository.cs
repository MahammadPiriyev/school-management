using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		public DbSet<T> dbSet;
		public BaseRepository(ApplicationDbContext context)
		{
			_context = context;
			this.dbSet = _context.Set<T>();
		}
		public void Add(T entity)
		{
			dbSet.Add(entity);
		}

		public IEnumerable<T> GetAll()
		{
			return dbSet.ToList();
		}

		public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			query = query.Where(filter);
			return query.FirstOrDefault();
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public int Count()
		{
			return dbSet.Count();
		}
	}
}
