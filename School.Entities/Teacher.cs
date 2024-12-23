using School.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
	public class Teacher : IBaseEntity
	{
		public int DepartmentId {  get; set; }
		public virtual Department Department { get; set; }
	}
}
