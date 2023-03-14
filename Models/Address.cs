using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
	public class Address
	{
        [Key]
        public string address_id { get; set; }
        public string street_no { get; set; }
        public string postal_code { get; set; }
        public string address_type { get; set; }
        public string city { get; set; }
        public string country { get; set; }

    }
}

