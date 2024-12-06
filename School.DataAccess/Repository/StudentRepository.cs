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
	public class StudentRepository : BaseRepository<Student>, IStudentRepository
	{
		private readonly ApplicationDbContext _context;
		public StudentRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		public void Update(Student student)
		{
			_context.Update(student);
		}
	}
}
