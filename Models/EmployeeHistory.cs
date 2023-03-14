using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class EmployeeHistory
    {
        [Key]
        public string historyid { get; set; }
        public string employeeid { get; set; }
        public string departmentid { get; set; }
        public string roleid { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }


    }
}

