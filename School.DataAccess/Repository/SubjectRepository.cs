using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository
{
	public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
	{
		private readonly ApplicationDbContext _context;
		public SubjectRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;	
		}

		public IEnumerable<Subject> GetSubjects(Expression<Func<Subject, bool>> filter)
		{
			return _context.Subjects.ToList();
		}

		public void Update(Subject subject)
		{
			_context.Update(subject);
		}
	}
}
