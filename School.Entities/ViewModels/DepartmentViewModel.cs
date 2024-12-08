using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.ViewModels
{
	public class DepartmentViewModel
	{
		public string DepartmentName { get; set; }
		public List<TeacherViewModel> Teachers { get; set; }
	}
}
