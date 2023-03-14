using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class EmployeeAddress
    {
        [Key]
        public string addressid { get; set; }
        public string employeeid { get; set; }
    }
}

