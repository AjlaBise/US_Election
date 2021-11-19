using System;
using System.Collections.Generic;
using System.Text;

namespace US_Election.Dal.Services.Interface
{
    public interface IElectorateService
    {
        List<Models.Electorate> GetAll();
    }
}
