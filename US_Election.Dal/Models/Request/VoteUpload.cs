namespace US_Election.Dal.Models.Request
{
    public class VoteUpload
    {

        public int CandidateId { get; set; }

        public int ElectorateId { get; set; }

        public int NumberOfVotes { get; set; }
    }
}