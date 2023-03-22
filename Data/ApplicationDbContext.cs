using System;
using Microsoft.EntityFrameworkCore;
using EmployeeVotingSystem.Models;
using System.Data.SqlClient;

namespace EmployeeVotingSystem.Models
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{ }
		public DbSet<EmployeeVotingSystem.Models.Address>? Address { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Department>? Department { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Email>? Email { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Employee>? Employee { get; set; }
		public DbSet<EmployeeVotingSystem.Models.EmployeeAddress>? EmployeeAddress { get; set; }
		public DbSet<EmployeeVotingSystem.Models.EmployeeHistory>? EmployeeHistory { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Job>? Job { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Manager>? Manager { get; set; }
		public DbSet<EmployeeVotingSystem.Models.Role>? Role { get; set; }
		public DbSet<EmployeeVotingSystem.Models.VoteRecord>? VoteRecord { get; set; }


    }
}

