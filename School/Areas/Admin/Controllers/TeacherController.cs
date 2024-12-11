using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.Business.Abstract;
using School.DataAccess.Data;
using School.DataAccess.Repository;
using School.DataAccess.Repository.IRepository;
using School.Entities;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TeacherController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ITeacherService _teacherService;
		public TeacherController(ApplicationDbContext context, ITeacherService teacherService)
		{
			_context = context;
			_teacherService = teacherService;
		}
		public IActionResult Index()
		{
			return View(_teacherService.GetAllTeachers());
		}
		public IActionResult Info(int id)
		{
			return View(_teacherService.GetTeacherInfo(id));
		}
		public IActionResult Add()
		{
			IEnumerable<SelectListItem> DepartmentList = _context.Departments.Select(d => new SelectListItem
			{
				Text = d.Name,
				Value = d.DepartmentId.ToString()
			});
			ViewData["DepartmentList"] = DepartmentList;
			return View();
		}
		[HttpPost]
		public IActionResult Add(Teacher teacher)
		{
			_teacherService.Add(teacher);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			IEnumerable<SelectListItem> DepartmentList = _context.Departments.Select(d => new SelectListItem
			{
				Text = d.Name,
				Value = d.DepartmentId.ToString()
			});
			ViewData["DepartmentList"] = DepartmentList;
			if (id == 0)
			{
				return NotFound();
			}
			return View(_teacherService.EditTeacher(id));
		}

		[HttpPost]
		public IActionResult Edit(Teacher teacher)
		{
			_teacherService.Edit(teacher);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			IEnumerable<SelectListItem> DepartmentList = _context.Departments.Select(d => new SelectListItem
			{
				Text = d.Name,
				Value = d.DepartmentId.ToString()
			});
			ViewData["DepartmentList"] = DepartmentList;
			return View(_teacherService.DeleteTeacher(id));
		}
		[HttpPost]
		public IActionResult Delete(Teacher teacher)
		{
			_teacherService.Delete(teacher);	
			return RedirectToAction(nameof(Index));
		}

	}
}
