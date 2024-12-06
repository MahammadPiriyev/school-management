using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Repository.IRepository;
using School.Entities;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ClassController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public ClassController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Class> classList = _unitOfWork.Classes.GetAll().ToList();
			return View(classList);
		}
		public IActionResult Info(int id)
		{
			var classFromDb = _unitOfWork.Classes.Get(c => c.ClassId == id);
			return View(classFromDb);
		}
		public IActionResult Add(int id)
		{
			var classFromDb = _unitOfWork.Classes.Get(c => c.ClassId == id);
			return View(classFromDb);
		}
		[HttpPost]
		public IActionResult Add(Class @class)
		{
			_unitOfWork.Classes.Add(@class);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Edit(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var classFromDb = _unitOfWork.Classes.Get(c => c.ClassId == id);
			if (classFromDb == null)
			{
				return NotFound();
			}
			return View(classFromDb);
		}
		[HttpPost]
		public IActionResult Edit(Class @class)
		{
			_unitOfWork.Classes.Update(@class);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			var classFromDb = _unitOfWork.Classes.Get(c => c.ClassId == id);
			return View(classFromDb);
		}

		[HttpPost]
		public IActionResult Delete(Class @class)
		{
			_unitOfWork.Classes.Remove(@class);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}
