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
    public class CandidateService : ICandidateService
    {
        private readonly US_ElectionDbContext _context;
        private readonly IMapper _mapper;

        public CandidateService(US_ElectionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Models.Candidate> GetAll()
        {
            var entity = _context.Candidates.ToList();

            return _mapper.Map<List<Models.Candidate>>(entity);
        }
    }
}
