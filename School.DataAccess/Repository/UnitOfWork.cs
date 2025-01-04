﻿using Microsoft.EntityFrameworkCore;
using School.DataAccess.Data;
using School.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		public IStudentRepository Students {  get; private set; }
		public ITeacherRepository Teachers { get; private set; }
		public IClassRepository Classes { get; private set; }
		public IDepartmentRepository Departments { get; private set; }
		public ISubjectRepository Subjects { get; private set; }
		public IExamRepository Exams { get; private set; }


		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Students = new StudentRepository(_context);
			Teachers = new TeacherRepository(_context);
			Classes = new ClassRepository(_context);
			Departments = new DepartmentRepository(_context);
			Subjects = new SubjectRepository(_context);
			Exams = new ExamRepository(_context);
		}
		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
