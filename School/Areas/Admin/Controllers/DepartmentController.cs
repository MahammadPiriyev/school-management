using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Repository.IRepository;
using School.Entities;

namespace School.Areas.Admin.Controllers
{
	public class DepartmentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public DepartmentController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			List<Department> departmentList = _unitOfWork.Departments.GetAll().ToList();
			return View(departmentList);	
		}

		public IActionResult Info(int id)
		{
			var departmentFromDb = _unitOfWork.Departments.Get(d => d.DepartmentId == id);
			return View(departmentFromDb);	
		}

		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Add(Department department)
		{
			_unitOfWork.Departments.Add(department);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var departmentFromDb = _unitOfWork.Departments.Get(d => d.DepartmentId == id);
			if (departmentFromDb == null)
			{
				return NotFound();
			}
			return View(departmentFromDb);
		}
		[HttpPost]
		public IActionResult Edit(Department department)
		{
			_unitOfWork.Departments.Update(department);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}
			var departmentFromDb = _unitOfWork.Departments.Get(d => d.DepartmentId == id);
			if (departmentFromDb == null)
			{
				return NotFound();
			}
			return View(departmentFromDb);
		}
		[HttpPost]
		public IActionResult Delete(Department department)
		{
			_unitOfWork.Departments.Remove(department);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
	}
}
