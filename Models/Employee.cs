using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class Employee
    {
        [Key]
        public string employeeid { get; set; }
        public string employeename { get; set; }
        public DateTime dob { get; set; }
        public string contact { get; set; }
        public string roleid { get; set; }
        public string departmentid { get; set; }




    }
}

