using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeVotingSystem.Models
{
    public class VoteRecord
    {
        [Key]
        public string recordid { get; set; }
        public string voterid { get; set; }
        public string candidateid { get; set; }
        public string votingyear { get; set; }
        public string votingmonth { get; set; }



    }
}

