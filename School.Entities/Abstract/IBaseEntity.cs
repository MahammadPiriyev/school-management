using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities.Abstract
{
	public abstract class IBaseEntity
	{
		[Key]
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Gender { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		[ValidateNever]
		public string Address { get; set; }
		public string ImageUrl { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime CreatedDate { get; set; }

	}
}
