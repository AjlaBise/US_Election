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
        private readonly IElectorateService _service;

        public ElectorateController(IElectorateService service)
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