using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using US_Election.Dal.Database;
using US_Election.Dal.Services.Interface;

namespace US_Election.Dal.Services
{
    public class VoteRepository : IVoteRepository
    {
        private readonly US_ElectionDbContext _context;
        private readonly IMapper _mapper;

        public VoteRepository(US_ElectionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Models.VoteViewModel>> GetAll()
        {
            var entity = await _context.Votes.ToListAsync();

            return _mapper.Map<List<Models.VoteViewModel>>(entity);
        }

        public async Task Update(string candidateCode, int electorateId, int numberOfVotes)
        {
            var vote = await _context.Votes.FirstOrDefaultAsync(x => x.Candidate.Code == candidateCode && x.ElectorateId == electorateId);
        
            if (vote != null)
            {
                vote.NumberOfVotes = numberOfVotes;
                vote.OverrideFile = true;

                await _context.SaveChangesAsync();
            }
        }
    }
}