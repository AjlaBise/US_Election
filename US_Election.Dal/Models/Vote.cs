using System;
using System.Collections.Generic;
using System.Text;

namespace US_Election.Dal.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }

        public int ElectorateId { get; set; }

        public int NumberOfVotes { get; set; }

        public bool? OverrideFile { get; set; }
    }
}
