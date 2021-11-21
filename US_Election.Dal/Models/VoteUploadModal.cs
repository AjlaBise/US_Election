using CsvHelper.Configuration.Attributes;
using System;

namespace US_Election.Dal.Models
{
    public class VoteUploadModal
    {
        [Index(0)]
        public string Electorate { get; set; } = "";

        [Index(1)]
        public string numberOfVotes { get; set; } = "";

        [Index(2)]
        public string CandidateCode { get; set; } = "";
    }
}