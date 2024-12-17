using Microsoft.AspNetCore.Mvc;
using School.Business.Abstract;
using School.DataAccess.Data;
using School.Entities;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ParentController : Controller
	{
		private readonly IParentService _parentService;
		private readonly ApplicationDbContext _context;
		public ParentController(IParentService parentService, ApplicationDbContext context)
		{
			_parentService = parentService;
			_context = context;
		}

		public IActionResult Index()
		{
			return View(_parentService.GetAllParents());
		}

		public IActionResult Info(int id)
		{
			return View(_parentService.GetParent(id));
		}

		public IActionResult Edit(int id)
		{
			return View(_parentService.GetParent(id));
		}
		[HttpPost]
		public IActionResult Edit(Parent parent)
		{
			_parentService.Edit(parent);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Delete(int id)
		{
			return View(_parentService.GetParent(id));
		}
		[HttpPost]
		public IActionResult Delete(Parent parent)
		{
			_parentService.Delete(parent);
			return RedirectToAction(nameof(Index));
		}
	}
}
