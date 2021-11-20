using System;
using System.Collections.Generic;
using System.Text;

namespace US_Election.Dal.Services.Interface
{
    public interface ICandidateService
    {
        List<Models.Candidate> GetAll();

    }
}
