using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
	public class Department
	{
		public int DepartmentId { get; set; }
		public string Name { get; set; }
		public virtual ICollection<Teacher> Teachers { get; set; }
	}
}
