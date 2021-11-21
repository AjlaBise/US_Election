using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Database;
using US_Election.Dal.Models;
using US_Election.Dal.Services.Interface;

namespace US_Election.Dal.Services
{
    public class ElectorateRepository : IElectorateRepository
    {
        private readonly US_ElectionDbContext _context;
        private readonly IMapper _mapper;

        public ElectorateRepository(US_ElectionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       public async Task<List<ElectorateViewModel>> GetAll()
       {
            var entity = await _context.Electorates.ToListAsync();

            return _mapper.Map<List<ElectorateViewModel>>(entity);
       }

        public async Task<int> GetElectorateId(string name)
        {
            var electorate = await _context.Electorates.FirstOrDefaultAsync(x => x.Name == name);

            return electorate.Id;
        }
    }
}