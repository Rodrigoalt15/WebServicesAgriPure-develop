using WebServicesAgriPure.Shared.Persistence.Contexts;

namespace WebServicesAgriPure.Shared.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
