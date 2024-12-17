using School.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
	public class Parent : IBaseEntity
	{
		public int StudentId { get; set; }
		public virtual Student Student { get; set; }
	}
}
