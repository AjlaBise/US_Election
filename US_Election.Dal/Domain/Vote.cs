namespace US_Election.Dal.Domain
{
    public class Vote
    {
        public int Id { get; set; }

        public Candidate Candidate { get; set; }

        public int CandidateId { get; set; }

        public Electorate Electorate { get; set; }

        public int ElectorateId { get; set; }

        public int NumberOfVotes { get; set; }

        public bool? OverrideFile { get; set; }
    }
}