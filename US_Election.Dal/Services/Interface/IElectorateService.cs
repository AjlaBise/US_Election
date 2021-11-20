using System.Collections.Generic;
using System.Threading.Tasks;

namespace US_Election.Dal.Services.Interface
{
    public interface IElectorateService
    {
        Task<List<Models.Electorate>> GetAll();
    }
}
