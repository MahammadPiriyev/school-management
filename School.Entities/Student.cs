using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using School.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
	public class Student : IBaseEntity
	{
		public string Class { get; set; }
		public int GPA { get; set; }
	}
}
