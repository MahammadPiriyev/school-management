﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		IStudentRepository Students { get; }
		ITeacherRepository Teachers { get; }
		IClassRepository Classes { get; }
		IDepartmentRepository Departments { get; }
		ISubjectRepository Subjects { get; }
		IExamRepository Exams { get; }
		void Save();
	}
}
