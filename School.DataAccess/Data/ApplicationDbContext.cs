using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Entities;
using School.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataAccess.Data
{
	public class ApplicationDbContext : IdentityDbContext<IdentityUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			
		}
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Class> Classes { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<ApplicationUser> applicationUser { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<IBaseEntity>().UseTpcMappingStrategy();
			//modelBuilder.Entity<Student>()
			//	.HasOne(c => c.Teacher)
			//	.WithMany(c => c.Students);
			modelBuilder.Entity<IdentityUserLogin<string>>()
				.HasNoKey();
			modelBuilder.Entity<IdentityUserRole<string>>()
				.HasNoKey();
			modelBuilder.Entity<IdentityUserToken<string>>()
				.HasNoKey();
			modelBuilder.Entity<Student>()
				.HasOne(s => s.Class)
				.WithMany(c => c.Students)
				.HasForeignKey(s => s.ClassId);
			modelBuilder.Entity<Teacher>()
				.HasOne(t => t.Department)
				.WithMany(d => d.Teachers)
				.HasForeignKey(t => t.DepartmentId);
		}
	}

}
