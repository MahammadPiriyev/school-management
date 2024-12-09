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
	public class StudentService : IStudentService
	{
		private readonly IUnitOfWork _unitOfWork;
		public StudentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void Add(Student student)
		{
			_unitOfWork.Students.Add(student);
			_unitOfWork.Save();
		}

		public void Delete(Student student)
		{
			_unitOfWork.Students.Remove(student);
			_unitOfWork.Save();
		}

		public Student DeleteStudent(int id)
		{
			var studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
			return studentFromDb;
		}

		public void Edit(Student student)
		{
			_unitOfWork.Students.Update(student);
			_unitOfWork.Save();	
		}

		public Student EditStudent(int id)
		{
			var studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
			return studentFromDb;
		}

		public IEnumerable<Student> GetAllStudents()
		{
			List<Student> students = _unitOfWork.Students.GetAll().ToList();
			return students;
		}

		public Student GetStudentInfo(int id)
		{
			var studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
			return studentFromDb;
		}
	}
}
