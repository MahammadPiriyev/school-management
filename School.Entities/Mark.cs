﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
	public class Mark
	{
		public int MarkId { get; set; }
		public double MarkValue { get; set; } 

		public int StudentId { get; set; }
		public virtual Student Student { get; set; }

		public int ExamId { get; set; }
		public virtual Exam Exam { get; set; }
	}
}
