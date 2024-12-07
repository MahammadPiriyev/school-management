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
	public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
	{
		private readonly ApplicationDbContext _context;
		public DepartmentRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(Department department)
		{
			_context.Update(department);	
		}
	}
}
