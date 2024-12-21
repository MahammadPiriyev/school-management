using Microsoft.AspNetCore.Authorization;
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
	[Authorize]
	public class TeacherController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly ITeacherService _teacherService;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public TeacherController(ApplicationDbContext context, ITeacherService teacherService, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_teacherService = teacherService;
			_webHostEnvironment = webHostEnvironment;
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
			IEnumerable<SelectListItem> SubjectList = _context.Subjects.Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.SubjectId.ToString()
			});
			ViewData["SubjectList"] = SubjectList;
			ViewData["DepartmentList"] = DepartmentList;
			return View();
		}
		[HttpPost]
		public IActionResult Add(Teacher teacher, IFormFile file)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;

			if (file != null)
			{
				// Generate unique file name
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

				// Construct path to the images/product folder inside wwwroot
				string productPath = Path.Combine(wwwRootPath, "images/teacher");

				// Ensure the directory exists
				if (!Directory.Exists(productPath))
				{
					Directory.CreateDirectory(productPath);
				}

				// Save the file to the constructed path
				using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
				{
					file.CopyTo(fileStream);
				}

				// Save the relative image path to the database
				teacher.ImageUrl = @"\images\teacher\" + fileName;
			}
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
			IEnumerable<SelectListItem> SubjectList = _context.Subjects.Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.SubjectId.ToString()
			});
			ViewData["SubjectList"] = SubjectList;
			ViewData["DepartmentList"] = DepartmentList;
			if (id == 0)
			{
				return NotFound();
			}
			return View(_teacherService.EditTeacher(id));
		}

		[HttpPost]
		public IActionResult Edit(Teacher teacher, IFormFile file)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;

			if (file != null)
			{
				// Generate unique file name
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

				// Construct path to the images/product folder inside wwwroot
				string productPath = Path.Combine(wwwRootPath, "images/teacher");

				// Ensure the directory exists
				if (!Directory.Exists(productPath))
				{
					Directory.CreateDirectory(productPath);
				}
				if (!string.IsNullOrEmpty(teacher.ImageUrl))
				{
					var oldImageUrl = Path.Combine(wwwRootPath, teacher.ImageUrl.TrimStart('\\'));
					if (System.IO.File.Exists(oldImageUrl))
					{
						System.IO.File.Delete(oldImageUrl);
					}
				}

				// Save the file to the constructed path
				using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
				{
					file.CopyTo(fileStream);
				}

				// Save the relative image path to the database
				teacher.ImageUrl = @"\images\teacher\" + fileName;
			}
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
			IEnumerable<SelectListItem> SubjectList = _context.Subjects.Select(u => new SelectListItem
			{
				Text = u.Name,
				Value = u.SubjectId.ToString()
			});
			ViewData["SubjectList"] = SubjectList;
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
