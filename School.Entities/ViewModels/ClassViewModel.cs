using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.ViewModels
{
	public class ClassViewModel
	{
		public string ClassName { get; set; }
		public List<StudentViewModel> Students { get; set; }
	}
}
