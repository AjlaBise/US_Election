using US_Election.Dal.Database;
using US_Election.Dal.Repositories.Interface;

namespace US_Election.Dal.Repositories
{
    public class ExceptionRepository : IExceptionRepository
    {
        private readonly US_ElectionDbContext _context;

        public ExceptionRepository(US_ElectionDbContext context)
        {
            _context = context;
        }

        public void Add(Exception exception)
        {
            _context.Exceptions.Add(exception);
            _context.SaveChanges();
        }
    }
}