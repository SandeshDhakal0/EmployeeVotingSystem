using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeVotingSystem.Models
{
	public class Email
	{
		[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Email_Address { get; set; }

		public int EmployeeID { get; set; }


    }
}

