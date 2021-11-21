using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Database;
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

       public async Task<List<Models.Electorate>> GetAll()
        {
            var entity = await _context.Electorates.ToListAsync();

            return _mapper.Map<List<Models.Electorate>>(entity);
        }
    }
}