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
	public class ParentRepository : BaseRepository<Parent>, IParentRepository
	{
		private readonly ApplicationDbContext _context;
		public ParentRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
		public void Update(Parent parent)
		{
			_context.Update(parent);
		}
	}
}
