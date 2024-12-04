using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository.IRepository
{
	public interface ITeacherRepository : IBaseRepository<Teacher>
	{
		void Update(Teacher teacher);
	}
}
