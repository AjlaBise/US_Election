using Microsoft.EntityFrameworkCore;

namespace US_Election.Dal.Database
{
    public partial class US_ElectionDbContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            #region Add Candidate
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = 1,
                    Name = "Donald Trump",
                    Code = "DT"
                },
                 new Candidate
                 {
                     Id = 2,
                     Name = "Hillary Clinton",
                     Code = "HC"
                 },
                  new Candidate
                  {
                      Id = 3,
                      Name = " Joe Biden",
                      Code = "JB"
                  },
                   new Candidate
                   {
                       Id = 4,
                       Name = "  John F. Kennedy",
                       Code = "JFK"
                   },
                    new Candidate
                    {
                        Id = 5,
                        Name = "Jack Randall",
                        Code = "JR"
                    }
                );

            #endregion

            #region Add Electorate

            modelBuilder.Entity<Electorate>().HasData(
               new Electorate
               {
                   Id = 1,
                   Name = "New York"
               },
                 new Electorate
                 {
                     Id = 2,
                     Name = "Washington"
                 },
                   new Electorate
                   {
                       Id = 3,
                       Name = "Texas"
                   }
               );

            #endregion

            #region Add Votes
            modelBuilder.Entity<Vote>().HasData(
                new Vote
                {
                    Id=1,
                    CandidateId=1,
                    ElectorateId=1,
                    NumberOfVotes=0,
                    OverrideFile = false
                },
                 new Vote
                 {
                     Id = 2,
                     CandidateId = 2,
                     ElectorateId =1,
                     NumberOfVotes = 0,
                     OverrideFile = false

                 },
                  new Vote
                  {
                      Id = 3,
                      CandidateId = 3,
                      ElectorateId = 1,
                      NumberOfVotes = 0,
                      OverrideFile = false

                  },
                   new Vote
                   {
                       Id = 4,
                       CandidateId = 4,
                       ElectorateId = 1,
                       NumberOfVotes = 0,
                       OverrideFile = false

                   },
                    new Vote
                    {
                        Id = 5,
                        CandidateId = 5,
                        ElectorateId = 1,
                        NumberOfVotes = 0,
                        OverrideFile = false

                    },
                     new Vote
                     {
                         Id = 6,
                         CandidateId = 1,
                         ElectorateId = 2,
                         NumberOfVotes = 0,
                         OverrideFile = false
                     },
                 new Vote
                 {
                     Id = 7,
                     CandidateId = 2,
                     ElectorateId = 2,
                     NumberOfVotes = 0,
                     OverrideFile = false

                 },
                  new Vote
                  {
                      Id = 8,
                      CandidateId = 3,
                      ElectorateId = 2,
                      NumberOfVotes = 0,
                      OverrideFile = false

                  },
                   new Vote
                   {
                       Id = 9,
                       CandidateId = 4,
                       ElectorateId = 2,
                       NumberOfVotes = 0,
                       OverrideFile = false

                   },
                    new Vote
                    {
                        Id = 10,
                        CandidateId = 5,
                        ElectorateId = 2,
                        NumberOfVotes = 0,
                        OverrideFile = false

                    },
                     new Vote
                     {
                         Id = 11,
                         CandidateId = 1,
                         ElectorateId = 3,
                         NumberOfVotes = 0,
                         OverrideFile = false
                     },
                 new Vote
                 {
                     Id = 12,
                     CandidateId = 2,
                     ElectorateId = 3,
                     NumberOfVotes = 0,
                     OverrideFile = false

                 },
                  new Vote
                  {
                      Id = 13,
                      CandidateId = 3,
                      ElectorateId = 3,
                      NumberOfVotes = 0,
                      OverrideFile = false

                  },
                   new Vote
                   {
                       Id = 14,
                       CandidateId = 4,
                       ElectorateId = 3,
                       NumberOfVotes = 0,
                       OverrideFile = false

                   },
                    new Vote
                    {
                        Id = 15,
                        CandidateId = 5,
                        ElectorateId = 3,
                        NumberOfVotes = 0,
                        OverrideFile = false

                    }
                );
            #endregion
        }
    }
}