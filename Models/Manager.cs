using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class Manager
    {
        [Key]
        public string departmentid { get; set; }
        public string managerid { get; set; }

    }
}

