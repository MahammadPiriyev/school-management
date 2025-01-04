using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.ViewModels
{
	public class MarkViewModel
	{
		public List<Student> Students { get; set; }
		public string ExamName { get; set; }
		public int ClassId { get; set; }
		public int MarkId { get; set; }
		public int ExamId { get; set; }
		public int StudentId { get; set; }
		public double MarkValue { get; set; }
	}
}
