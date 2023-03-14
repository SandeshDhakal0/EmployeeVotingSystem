using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class Email
    {
        [Key]
        public string email { get; set; }
        public int age { get; set; }
        public string employeeid { get; set; }

    }
}

