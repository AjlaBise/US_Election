using AutoMapper;

namespace US_Election.Dal.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Vote, Models.Vote>();
            CreateMap<Database.Electorate, Models.Electorate>();
            CreateMap<Database.Candidate, Models.Candidate>();

            CreateMap<Models.VoteUploadModal, Database.Vote>();
        }
    }
}
