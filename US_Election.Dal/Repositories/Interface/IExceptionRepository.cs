using US_Election.Dal.Database;
using US_Election.Dal.Domain;

namespace US_Election.Dal.Repositories.Interface
{
    public interface IExceptionRepository
    {
        void Add(Exception exception);
    }
}