using System;
using Microsoft.EntityFrameworkCore;
using EmployeeVotingSystem.Models;

namespace EmployeeVotingSystem.Models
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{ }
		public DbSet<EmployeeVotingSystem.Models.Department>? Department { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Job>? Job { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Address>? Address { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Role>? Role { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Employee>? Employee { get; set; }
		public DbSet<EmployeeVotingSystem.Models.DeptManager>? DeptManager { get; set; }
		public DbSet<EmployeeVotingSystem.Models.JobHistory>? JobHistory { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Vote>? Vote { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Email>? Email { get; set; }
		
		



		
		


    }
}

