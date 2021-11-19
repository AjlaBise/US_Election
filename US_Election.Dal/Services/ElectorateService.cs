using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using US_Election.Dal.Database;
using US_Election.Dal.Models;
using US_Election.Dal.Services.Interface;

namespace US_Election.Dal.Services
{
    public class ElectorateService : IElectorateService
    {
        private readonly US_ElectionDbContext _context;
        private readonly IMapper _mapper;

        public ElectorateService(US_ElectionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       public List<Models.Electorate> GetAll()
        {
            var entity = _context.Electorates.ToList();

            return _mapper.Map<List<Models.Electorate>>(entity);
        }
    }
}
