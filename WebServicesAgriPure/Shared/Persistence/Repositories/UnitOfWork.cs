using System;
using WebServicesAgriPure.AgriPure.Domain.Repositories;
using WebServicesAgriPure.Shared.Persistence.Contexts;

namespace WebServicesAgriPure.Shared.Persistence.Repositories
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
