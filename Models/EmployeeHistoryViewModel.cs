using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class EmployeeHistoryViewModel
    {
        public string historyid { get; set; }
        public string employeeid { get; set; }
        public string employeename { get; set; }
        public DateTime dob { get; set; }
        public string departmentid { get; set; }
        public string departmentname { get; set; }
        public string description { get; set; }
        public string roleid { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
    }

}

