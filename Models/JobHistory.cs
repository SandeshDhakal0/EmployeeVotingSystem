using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeVotingSystem.Models
{
	public class JobHistory
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobHistoryID { get; set; }
        public DateTime? startdate { get; set; }
        public DateTime? enddate { get; set; }

        public int DepartmentID { get; set; }
        public int RoleID { get; set; }
        
    }
}

