using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using School.Entities.ViewModels;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class SubjectController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;
		public SubjectController(IUnitOfWork unitOfWork, ApplicationDbContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}

		public IActionResult Index()
		{
			List<Subject> subjectList = _unitOfWork.Subjects.GetAll().ToList();
			List<Class> classList = _unitOfWork.Classes.GetAll().ToList();
			var subjectViewModel = new SubjectViewModel
			{
				ClassList = classList,
				SubjectList = subjectList
			};
			return View(subjectViewModel);
		}
		//public IActionResult GetSubjects(int classId)
		//{
		//	var subjects = _context.Subjects
		//						   .Where(s => s.ClassId == classId)
		//						   .Select(s => new { s.SubjectId, s.Name })
		//						   .ToList();
		//	return View(subjects);
		//}
		public IActionResult GetClasses()
		{
			IEnumerable<SelectListItem> ClassList = _context.Classes.Select(c => new SelectListItem
			{
				Text = c.Name,
				Value = c.ClassId.ToString()
			});
			ViewData["ClassList"] = ClassList;
			return View(ClassList);
		}
		public IActionResult Info(int id)
		{
			var subjectFromDb = _unitOfWork.Subjects.Get(s => s.SubjectId == id);
			return View(subjectFromDb);
		}
		public IActionResult Add()
		{
			IEnumerable<SelectListItem> ClassList = _context.Classes.Select(c => new SelectListItem
			{
				Text = c.Name,
				Value = c.ClassId.ToString()
			});
			ViewData["ClassList"] = ClassList;
			return View();
		}
		[HttpPost]
		public IActionResult Add(Subject subject)
		{
			_unitOfWork.Subjects.Add(subject);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Edit(int id)
		{
			IEnumerable<SelectListItem> ClassList = _context.Classes.Select(c => new SelectListItem
			{
				Text = c.Name,
				Value = c.ClassId.ToString()
			});
			ViewData["ClassList"] = ClassList;
			if (id == 0)
			{
				return NotFound();
			}
			var subjectFromDb = _unitOfWork.Subjects.Get(c => c.SubjectId == id);
			if (subjectFromDb == null)
			{
				return NotFound();
			}
			return View(subjectFromDb);
		}
		[HttpPost]
		public IActionResult Edit(Subject subject)
		{
			_unitOfWork.Subjects.Update(subject);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			IEnumerable<SelectListItem> ClassList = _context.Classes.Select(c => new SelectListItem
			{
				Text = c.Name,
				Value = c.ClassId.ToString()
			});
			ViewData["ClassList"] = ClassList;
			var subjectFromDb = _unitOfWork.Subjects.Get(c => c.SubjectId == id);
			return View(subjectFromDb);
		}

		[HttpPost]
		public IActionResult Delete(Subject subject)
		{
			_unitOfWork.Subjects.Remove(subject);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}
