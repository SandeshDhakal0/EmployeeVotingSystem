using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeVotingSystem.Models
{
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VoteID { get; set; }
        public int VotingYear { get; set; }
        public int VotingMonth { get; set; }
        public int CandidateID { get; set; }
        

    }
}
