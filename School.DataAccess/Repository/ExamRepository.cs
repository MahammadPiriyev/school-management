using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository
{
	public class ExamRepository : BaseRepository<Exam>, IExamRepository
	{
		private readonly ApplicationDbContext _context;
		public ExamRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Exam exam)
		{
			_context.Update(exam);
		}
	}
}
