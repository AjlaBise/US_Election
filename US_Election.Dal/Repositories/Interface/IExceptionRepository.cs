using US_Election.Dal.Database;

namespace US_Election.Dal.Repositories.Interface
{
    public interface IExceptionRepository
    {
        void Add(Exception exception);
    }
}