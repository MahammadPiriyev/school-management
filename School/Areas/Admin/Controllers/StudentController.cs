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
using Microsoft.AspNetCore.Authorization;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]

	public class StudentController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;
		private readonly IStudentService _studentService;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public StudentController(IUnitOfWork unitOfWork, ApplicationDbContext context, IStudentService studentService, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_context = context;
			_studentService = studentService;
			_webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{
			return View(_studentService.GetAllStudents());
		}
		public IActionResult Info(int id)
		{
			return View(_studentService.GetStudentInfo(id));
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
		public IActionResult Add(Student student, IFormFile file)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;

			if (file != null)
			{
				// Generate unique file name
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

				// Construct path to the images/product folder inside wwwroot
				string productPath = Path.Combine(wwwRootPath, "images/student");

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
				student.ImageUrl = @"\images\student\" + fileName;
			}
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
		public IActionResult Edit(Student student, IFormFile file)
		{
			string wwwRootPath = _webHostEnvironment.WebRootPath;

			if (file != null)
			{
				// Generate unique file name
				string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

				// Construct path to the images/product folder inside wwwroot
				string productPath = Path.Combine(wwwRootPath, "images/student");

				// Ensure the directory exists
				if (!Directory.Exists(productPath))
				{
					Directory.CreateDirectory(productPath);
				}
				if (!string.IsNullOrEmpty(student.ImageUrl))
				{
					var oldImageUrl = Path.Combine(wwwRootPath, student.ImageUrl.TrimStart('\\'));
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
				student.ImageUrl = @"\images\student\" + fileName;
			}
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
