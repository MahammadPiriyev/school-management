using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IStudentRepository Students { get; }
		ITeacherRepository Teachers { get; }
		IClassRepository Classes { get; }
		void Save();
	}
}
