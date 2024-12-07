using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DataAccess.Data;
using School.DataAccess.Repository;
using School.DataAccess.Repository.IRepository;
using School.Entities;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TeacherController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;
		public TeacherController(IUnitOfWork unitOfWork, ApplicationDbContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}
		public IActionResult Index()
		{
			var teacherList = _unitOfWork.Teachers.GetAll().ToList();
			return View(teacherList);
		}
		public IActionResult Info(int id)
		{
			var teacherFromDb = _unitOfWork.Teachers.Get(t => t.Id == id);
			return View(teacherFromDb);
		}
		public IActionResult Add()
		{
			//IEnumerable<SelectListItem> DepartmentList = _context.Departments.Select(d => new SelectListItem
			//{
			//	Text = d.Name,
			//	Value = d.DepartmentId
			//});
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

		public IActionResult Delete(int id)
		{
			var teacherFromDb = _unitOfWork.Teachers.Get(s => s.Id == id);
			return View(teacherFromDb);
		}
		[HttpPost]
		public IActionResult Delete(Teacher teacher)
		{
			_unitOfWork.Teachers.Remove(teacher);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

	}
}
