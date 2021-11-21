using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Models;
using US_Election.Dal.Models.Request;

namespace US_Election.Services.Interface
{
    public interface IVoteService
    {
        Task<VoteViewModel> UploadVote(FileModel file);

        Task<List<VoteUploadViewModel>> ReadCreateCSV(string fileName);
    }
}