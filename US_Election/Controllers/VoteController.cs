using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using US_Election.Dal.Database;
using US_Election.Dal.Models;
using US_Election.Dal.Services.Interface;

namespace US_Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _service;

        public VoteController(IVoteService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getVotes")]
        public List<Dal.Models.Vote> GetAll()
        {
                return _service.GetAll();
        }

        [HttpPost]
        [Route("postVotes")]
        public List<Dal.Models.Vote> UploadFile([FromForm] FileModel file)
        {
            try
            {
                return _service.UploadVote(file);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
            }

            return null;
        }
    }
}
