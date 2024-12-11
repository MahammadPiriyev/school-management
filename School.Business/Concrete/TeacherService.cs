using School.Business.Abstract;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Concrete
{
	public class TeacherService : ITeacherService
	{
		private readonly IUnitOfWork _unitOfWork;
		public TeacherService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void Add(Teacher teacher)
		{
			_unitOfWork.Teachers.Add(teacher);
			_unitOfWork.Save();
		}

		public void Delete(Teacher teacher)
		{
			_unitOfWork.Teachers.Remove(teacher);
			_unitOfWork.Save();
		}

		public Teacher DeleteTeacher(int id)
		{
			var teacherFromDb = _unitOfWork.Teachers.Get(t => t.Id == id);
			return teacherFromDb;
		}

		public void Edit(Teacher teacher)
		{
			_unitOfWork.Teachers.Update(teacher);
			_unitOfWork.Save();
		}

		public Teacher EditTeacher(int id)
		{
			var teacherFromDb = _unitOfWork.Teachers.Get(t => t.Id == id);
			return teacherFromDb;
		}

		public IEnumerable<Teacher> GetAllTeachers()
		{
			List<Teacher> teacherList = _unitOfWork.Teachers.GetAll().ToList();
			return teacherList;	
		}

		public Teacher GetTeacherInfo(int id)
		{
			var teacherFromDb = _unitOfWork.Teachers.Get(t => t.Id == id);
			return teacherFromDb;
		}
	}
}
