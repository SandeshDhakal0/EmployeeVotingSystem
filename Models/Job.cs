using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeVotingSystem.Models
{
	public class Job
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Job_ID { get; set; }

		public string? Job_name { get; set; }

		public int? Salary { get; set; }

    }
}

