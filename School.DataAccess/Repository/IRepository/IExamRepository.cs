using School.Entities;

namespace School.DataAccess.Repository.IRepository
{
	public interface IExamRepository : IBaseRepository<Exam>
	{
		void Update(Exam exam);
	}
}
