using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Services.Interface;

namespace US_Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectorateController : ControllerBase
    {
        private readonly IElectorateRepository _electorateRepository;

        public ElectorateController(IElectorateRepository electorateRepository)
        {
            _electorateRepository = electorateRepository;
        }

        [HttpGet]
        [Route("electorates")]
        public async Task<List<Dal.Models.ElectorateViewModel>> GetAll()
        {
            try
            {
                return await _electorateRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}