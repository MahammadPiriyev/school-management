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
	public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
	{
		private readonly ApplicationDbContext _context;
		public TeacherRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Teacher teacher)
		{
			_context.Update(teacher);
		}
	}
}
