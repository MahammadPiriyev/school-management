using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Repository;
using School.DataAccess.Repository.IRepository;
using School.Entities;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TeacherController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public TeacherController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var teacherList = _unitOfWork.Teachers.GetAll().ToList();
			return View(teacherList);
		}
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Teacher teacher)
		{
			_unitOfWork.Teachers.Add(teacher);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var teacherFromDb = _unitOfWork.Teachers.Get(t => t.Id == id);
			if (teacherFromDb == null)
			{
				return NotFound();
			}
			return View(teacherFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Teacher teacher)
		{
			_unitOfWork.Teachers.Update(teacher);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
			if (studentFromDb == null)
			{
				return NotFound();
			}
			_unitOfWork.Students.Remove(studentFromDb);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

	}
}
