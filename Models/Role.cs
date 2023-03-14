using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class Role
    {
        [Key]
        public string roleid { get; set; }
        public string jobid { get; set; }
        public string title { get; set; }
        public string description { get; set; }

    }
}

