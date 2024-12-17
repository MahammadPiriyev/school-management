using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Abstract
{
	public interface IParentService
	{
		IEnumerable<Parent> GetAllParents();
		Parent GetParent(int id);
		void Add(Parent parent);
		void Edit(Parent parent);
		void Delete(Parent parent);

	}
}
