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
    public class ElectorateControler : ControllerBase
    {
        private readonly IElectorateService _service;

        public ElectorateControler(IElectorateService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("getElectorate")]
        public List<Dal.Models.Electorate> GetAll()
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
