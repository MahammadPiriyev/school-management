using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DataAccess.Data;
using School.DataAccess.Repository;
using School.DataAccess.Repository.IRepository;
using School.Entities;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StudentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;
		public IEnumerable<Student> Students { get; set; }
		public StudentController(IUnitOfWork unitOfWork, ApplicationDbContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}
		public IActionResult Index()
		{
			List<Student> studentList = _unitOfWork.Students.GetAll().ToList();
			return View(studentList);
		}
		public IActionResult Info(int id)
		{
			Student studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
			return View(studentFromDb);
		}
		public IActionResult Get(int id)
		{
			var studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
			return View(studentFromDb);
		}
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
			_unitOfWork.Students.Add(student);
			_unitOfWork.Save();
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
			var studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
			if (studentFromDb == null)
			{
				return NotFound();
			}
			return View(studentFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Student student)
		{
			_unitOfWork.Students.Update(student);
			_unitOfWork.Save();
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
			var studentFromDb = _unitOfWork.Students.Get(s => s.Id == id);
			return View(studentFromDb);
		}
		[HttpPost]
		public IActionResult Delete(Student student)
		{
			_unitOfWork.Students.Remove(student);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

	}
}
