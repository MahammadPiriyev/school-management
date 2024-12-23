using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository.IRepository
{
	public interface ISubjectRepository : IBaseRepository<Subject>
	{
		IEnumerable<Subject> GetSubjects(Expression<Func<Subject, bool>> filter);
		void Update(Subject subject);
	}
}
