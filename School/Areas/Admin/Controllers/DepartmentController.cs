using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using School.Entities.ViewModels;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DepartmentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;
		public DepartmentController(IUnitOfWork unitOfWork, ApplicationDbContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}
		public IActionResult Index()
		{
			List<Department> departmentList = _unitOfWork.Departments.GetAll().ToList();
			return View(departmentList);	
		}

		public IActionResult Info(int id)
		{
			var departmentFromDb = _unitOfWork.Departments.Get(d => d.DepartmentId == id);
			var departmentViewModel = new DepartmentViewModel
			{
				DepartmentName = departmentFromDb.Name,
				Teachers = departmentFromDb.Teachers
				.Select(t => new TeacherViewModel {Id = t.Id, FirstName = t.FirstName, LastName = t.LastName})
				.ToList()
			};
			return View(departmentViewModel);	
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
