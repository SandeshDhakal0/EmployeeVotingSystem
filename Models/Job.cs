using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class Job
    {
        [Key]
        public string jobid { get; set; }
        public string jobtitle { get; set; }
        public int minsalary { get; set; }
        public int maxsalary { get; set; }

    }
}

