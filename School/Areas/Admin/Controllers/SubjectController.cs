using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Entities;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
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
			List<Subject> SubjectList = _unitOfWork.Subjects.GetAll().ToList();
			return View(SubjectList);
		}

		public IActionResult Info(int id)
		{
			var subjectFromDb = _unitOfWork.Subjects.Get(s => s.SubjectId == id);
			return View(subjectFromDb);
		}
		public IActionResult Add()
		{
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
