using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
	public class Subject
	{
		public int SubjectId { get; set; }
		public string Name { get; set; }
		public int LessonHours { get; set; }

		public int ClassId { get; set; }
		public virtual Class Class { get; set; }
	}
}
