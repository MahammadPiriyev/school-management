using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Abstract
{
	public interface IStudentService
	{
		IEnumerable<Student> GetAllStudents();
		Student GetStudentInfo(int id);
		void Add(Student student);
		Student EditStudent(int id);
		void Edit(Student student);
		Student DeleteStudent(int id);
		void Delete(Student student);
	}
}
