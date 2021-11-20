using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Models;
using US_Election.Dal.Models.Request;

namespace US_Election.Dal.Services.Interface
{
    public interface IVoteService
    {
        Models.Vote UploadVote(FileModel file);

        Task<List<Models.Vote>> GetAll();
    }
}
