using AutoMapper;
using US_Election.Dal.Database;

namespace US_Election.Dal.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            AutoMapperShared shared = new AutoMapperShared();

            CreateMap<Database.Vote, Models.Vote>().ForMember(dest => dest.CandidateName,
                opt => opt.MapFrom(src => shared.MapIdToName(src.CandidateId)));

            CreateMap<Database.Electorate, Models.Electorate>();
            CreateMap<Models.VoteUploadModal, Database.Vote>();
        }
    }

    public class AutoMapperShared
    {
        public string MapIdToName(int candidateId)
        {
            US_ElectionDbContext _context = new US_ElectionDbContext();

            var candidate = _context.Candidates.Find(candidateId);

            return candidate.Name;
        }
    }
}