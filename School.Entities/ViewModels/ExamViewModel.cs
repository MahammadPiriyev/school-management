using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.ViewModels
{
	public class ExamViewModel
	{
		public List<Exam> Exams { get; set; }
		public List<Class> Classes { get; set; }
	}
}
