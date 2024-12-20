using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using School.Entities.ViewModel;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DashboardController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		public DashboardController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var teachersCount = _unitOfWork.Teachers.Count();
			var studentsCount = _unitOfWork.Students.Count();
			var classCount = _unitOfWork.Classes.Count();

			var dashboardViewModel = new DashboardViewModel
			{
				TeachersCount = teachersCount,
				StudentsCount = studentsCount,
				ClassCount = classCount
			};
			return View(dashboardViewModel);
		}

	}
}
