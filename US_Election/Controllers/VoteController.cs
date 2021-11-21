using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Models;
using US_Election.Dal.Models.Request;
using US_Election.Dal.Services.Interface;
using US_Election.Services.Interface;

namespace US_Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoteController : ControllerBase
    {
        private readonly IVoteRepository _voteRepository;
        private readonly IVoteService _voteService;

        public VoteController(IVoteRepository voteRepository, IVoteService voteService)
        {
            _voteRepository = voteRepository;
            _voteService = voteService;
        }

        [HttpGet]
        [Route("votes")]
        public async Task<List<VoteViewModel>> GetAll()
        {
            try
            {
                return await _voteRepository.GetAll();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("postVotes")]
        public async Task<VoteViewModel> UploadFile([FromForm] FileModel file)
        {
            try
            {
                return await _voteService.UploadVote(file);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}