using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Models;
using US_Election.Dal.Models.Request;

namespace US_Election.Dal.Services.Interface
{
    public interface IVoteRepository
    {
        VoteViewModel UploadVote(FileModel file);

        Task<List<VoteViewModel>> GetAll();
    }
}