using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
	public class Class
	{
		public int ClassId { get; set; }
		public string Name { get; set; }
		public string RoomNumber { get; set; }
		public DateTime CreatedDate { get; set; }
		public virtual ICollection<Student> Students { get; set; }
	}
}
