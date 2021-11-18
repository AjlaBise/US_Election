using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using US_Election.Dal.Models.Request;

namespace US_Election.Dal.Services.Interface
{
    public interface IVoteService
    {
        [System.Obsolete]
        List<Models.Vote> UploadVote(IFormFile file, IHostingEnvironment hostingEnvironment);
    }
}
