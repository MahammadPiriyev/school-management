using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DataAccess.Data;
using School.DataAccess.Repository;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using StackExchange.Redis;
using System.Text.Json.Serialization;
using System.Text.Json;
using School.Business.Abstract;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StudentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;
		private readonly IStudentService _studentService;
		public StudentController(IUnitOfWork unitOfWork, ApplicationDbContext context, IStudentService studentService)
		{
			_unitOfWork = unitOfWork;
			_context = context;
			_studentService = studentService;
		}
		public IActionResult Index()
		{
			return View(_studentService.GetAllStudents());
		}
		public IActionResult Info(int id)
		{
			return View(_studentService.GetStudentInfo(id));
		}
		//public IActionResult Get(int id)
		//{
		//	var studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
		//	return View(studentFromDb);
		//}
		public IActionResult Add()
		{
			IEnumerable<SelectListItem> ClassList = _context.Classes.Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.ClassId.ToString()
			});
			ViewData["ClassList"] = ClassList;
			return View();
		}
		[HttpPost]
		public IActionResult Add(Student student)
		{
			_studentService.Add(student);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			IEnumerable<SelectListItem> ClassList = _context.Classes.Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.ClassId.ToString()
			});
			ViewData["ClassList"] = ClassList;
			if (id == 0)
			{
				return NotFound();
			}
			return View(_studentService.EditStudent(id));
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{
			_studentService.Edit(student);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			IEnumerable<SelectListItem> ClassList = _context.Classes.Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.ClassId.ToString()
			});
			ViewData["ClassList"] = ClassList;
			return View(_studentService.DeleteStudent(id));
		}
		[HttpPost]
		public IActionResult Delete(Student student)
		{
			_studentService.Delete(student);
			return RedirectToAction(nameof(Index));
		}

	}
}
