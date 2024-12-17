using School.Business.Abstract;
using School.DataAccess.Repository.IRepository;
using School.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Business.Concrete
{
	public class ParentService : IParentService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ParentService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public void Add(Parent parent)
		{
			_unitOfWork.Parents.Add(parent);
			_unitOfWork.Save();
		}

		public void Delete(Parent parent)
		{
			_unitOfWork.Parents.Remove(parent);
			_unitOfWork.Save();
		}

		public void Edit(Parent parent)
		{
			_unitOfWork.Parents.Update(parent);
			_unitOfWork.Save();
		}

		public IEnumerable<Parent> GetAllParents()
		{
			List<Parent> parentList = _unitOfWork.Parents.GetAll().ToList();
			return parentList;	
		}

		public Parent GetParent(int id)
		{
			var parentFromDb = _unitOfWork.Parents.Get(p => p.Id == id);
			return parentFromDb;
		}
	}
}
