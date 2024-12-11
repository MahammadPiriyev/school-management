using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Abstract
{
	public interface ITeacherService
	{
		IEnumerable<Teacher> GetAllTeachers();
		Teacher GetTeacherInfo(int id);
		void Add(Teacher teacher);
		Teacher EditTeacher(int id);
		void Edit(Teacher teacher);
		Teacher DeleteTeacher(int id);
		void Delete(Teacher teacher);
	}
}
