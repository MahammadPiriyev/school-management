using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using School.Entities.ViewModels;

namespace School.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ExamController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ApplicationDbContext _context;
		public ExamController(IUnitOfWork unitOfWork, ApplicationDbContext context)
		{
			_unitOfWork = unitOfWork;
			_context = context;
		}
		public IActionResult Index()
		{
			List<Exam> ExamList = _unitOfWork.Exams.GetAll().ToList();
			List<Class> ClassList = _unitOfWork.Classes.GetAll().ToList();
			var examViewModel = new ExamViewModel
			{
				Exams = ExamList,
				Classes = ClassList
			};
			return View(examViewModel);
		}
		public IActionResult Mark(int id)
		{
			var examFromDb = _unitOfWork.Exams.Get(e => e.Id == id);
			var markViewModel = new MarkViewModel
			{
				ExamName = examFromDb.ExamName,
				Students = examFromDb.Class.Students.ToList(),
				ClassId = examFromDb.ClassId,
				ExamId = id,
			};
			return View(markViewModel);
		}
		[HttpPost]
		public IActionResult Mark(int ExamId, int StudentId, int MarkValue)
		{
			var existingMark = _context.Marks
					.FirstOrDefault(m => m.ExamId == ExamId && m.StudentId == StudentId);
			if (existingMark != null)
			{
				existingMark.MarkValue = MarkValue;
				_context.Marks.Update(existingMark);
			}
			else
			{
				var newMark = new Mark
				{
					ExamId = ExamId,
					StudentId = StudentId,
					MarkValue = MarkValue
				};
				_context.Marks.Add(newMark);
			}

			_context.SaveChanges();

			return RedirectToAction(nameof(Mark));
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
		public IActionResult Add(Exam exam)
		{
			_unitOfWork.Exams.Add(exam);
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
			var examFromDb = _unitOfWork.Exams.Get(e => e.Id == id);
			if (examFromDb == null)
			{
				return NotFound();
			}
			return View(examFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Exam exam)
		{
			_unitOfWork.Exams.Update(exam);
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
			if (id == 0)
			{
				return NotFound();
			}
			var examFromDb = _unitOfWork.Exams.Get(e => e.Id == id);
			if (examFromDb == null)
			{
				return NotFound();
			}
			return View(examFromDb);
		}
		[HttpPost]
		public IActionResult Delete(Exam exam)
		{
			_unitOfWork.Exams.Remove(exam);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));	
		}
	}
}
