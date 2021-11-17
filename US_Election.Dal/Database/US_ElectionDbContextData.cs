using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

            #region
            modelBuilder.Entity<Vote>().HasData(
                new Vote
                {
                    Id=1,
                    CandidateId=1,
                    ElectorateId=1,
                    NumberOfVotes=4287
                },
                 new Vote
                 {
                     Id = 2,
                     CandidateId = 2,
                     ElectorateId = 2,
                     NumberOfVotes = 7287
                 },
                  new Vote
                  {
                      Id = 3,
                      CandidateId = 3,
                      ElectorateId = 3,
                      NumberOfVotes = 12547
                  },
                   new Vote
                   {
                       Id = 4,
                       CandidateId = 4,
                       ElectorateId = 1,
                       NumberOfVotes = 74287
                   },
                    new Vote
                    {
                        Id = 5,
                        CandidateId = 1,
                        ElectorateId = 2,
                        NumberOfVotes = 11287
                    }
                );
            #endregion
        }
    }
}
