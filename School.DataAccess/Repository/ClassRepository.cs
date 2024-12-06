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
	public class ClassRepository : BaseRepository<Class>, IClassRepository
	{
		private readonly ApplicationDbContext _context;
		public ClassRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(Class entity)
		{
			_context.Update(entity);
		}
	}
}
