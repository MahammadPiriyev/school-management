using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository.IRepository
{
	public interface IDepartmentRepository : IBaseRepository<Department>
	{
		void Update(Department department);
	}
}
