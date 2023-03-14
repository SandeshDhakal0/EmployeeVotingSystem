using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeVotingSystem.Models
{
    
        public class Department
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int dep_id { get; set; }

            [Required]
            public string? dep_name { get; set; }

        }
    
}

