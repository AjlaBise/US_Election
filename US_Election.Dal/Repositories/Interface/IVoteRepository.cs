using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Models;

namespace US_Election.Dal.Services.Interface
{
    public interface IVoteRepository
    {
        Task<List<VoteViewModel>> GetAll();

        Task Update(string candidateCode, int electorateId, int numberOfVotes);
    }
}