using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
	public class Exam
	{
		public int Id { get; set; }
		public string ExamName { get; set; }
		public DateTime ExamDate { get; set; }

		public int ClassId { get; set; }
		public virtual Class Class { get; set; }

		public virtual ICollection<Mark> Marks { get; set; }
	}
}
