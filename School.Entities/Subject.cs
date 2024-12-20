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
		public virtual ICollection<Teacher> Teachers { get; set; }
	}
}
