using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using US_Election.Dal.Services.Interface;

namespace US_Election.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectorateControler : ControllerBase
    {
        private readonly IElectorateService _service;

        public ElectorateControler(IElectorateService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getElectorate")]
        public async Task<List<Dal.Models.Electorate>> GetAll()
        {
            try
            {
                return await _service.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
