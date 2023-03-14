using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class Department
    {
        [Key]
        public string departmentid { get; set; }
        public string departmentname { get; set; }
       
    }
}

