using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository.IRepository
{
	public interface IBaseRepository<T> where T : class
	{
		IEnumerable<T> GetAll();

		T Get(Expression<Func<T, bool>> filter);

		void Add(T entity);
		void Remove(T entity);
		int Count();
	}
}
