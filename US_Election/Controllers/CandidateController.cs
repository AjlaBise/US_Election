using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using US_Election.Dal.Services.Interface;

namespace US_Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _service;

        public CandidateController(ICandidateService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getCandidate")]
        public List<Dal.Models.Candidate> GetAll()
        {
            try
            {
                return _service.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
