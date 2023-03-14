using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeVotingSystem.Models
{
	public class Employee
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }
        public string? EmpName { get; set; }
        public DateTime? dob { get; set; }
        public string? contact { get; set; }

        public int? dept_id { get; set; }
        public int? role_id { get; set; }
    }
}

