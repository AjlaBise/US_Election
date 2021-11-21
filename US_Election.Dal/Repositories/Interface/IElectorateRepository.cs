using System.Collections.Generic;
using System.Threading.Tasks;
using US_Election.Dal.Models;

namespace US_Election.Dal.Services.Interface
{
    public interface IElectorateRepository
    {
        Task<List<ElectorateViewModel>> GetAll();

        Task<int> GetElectorateId(string name);
    }
}