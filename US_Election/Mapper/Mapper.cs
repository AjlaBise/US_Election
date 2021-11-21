using AutoMapper;
using System.Linq;
using US_Election.Dal.Database;

namespace US_Election.Dal.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            AutoMapperShared shared = new AutoMapperShared();

            CreateMap<Domain.Vote, Models.VoteViewModel>().ForMember(dest => dest.CandidateName,
                opt => opt.MapFrom(src => shared.MapIdToName(src.CandidateId)))
            .ForMember(dest => dest.Parcentage,
                opt => opt.MapFrom(src => shared.MapParcentange(src.ElectorateId, src.CandidateId)));

            CreateMap<Domain.Electorate, Models.ElectorateViewModel>();
            CreateMap<Models.VoteUploadViewModel, Domain.Vote>();
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

        public float MapParcentange(int electorateId, int candidateId)
        {
            US_ElectionDbContext _context = new US_ElectionDbContext();

            var sumVotes = _context.Votes.Where(x => x.ElectorateId == electorateId).ToList().Sum(x => x.NumberOfVotes);

            var candidateVotes = _context.Votes.FirstOrDefault(x => x.CandidateId == candidateId).NumberOfVotes;

            if (sumVotes == 0 || candidateVotes == 0)
            {
                return 0;
            }
                return (float)((candidateVotes / sumVotes) * 100.00);           
        }
    }
}