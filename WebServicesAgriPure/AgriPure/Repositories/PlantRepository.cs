using Microsoft.EntityFrameworkCore;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Domain.Repositories;
using WebServicesAgriPure.Shared.Persistence.Contexts;
using WebServicesAgriPure.Shared.Persistence.Repositories;

namespace WebServicesAgriPure.AgriPure.Repositories
{
    public class PlantRepository: BaseRepository, IPlantRepository
    {
        public PlantRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Plant>> ListAsync()
        {
            return await _context.Plants.ToListAsync();
        }

        public async Task AddAsync(Plant plant)
        {
            await _context.Plants.AddAsync(plant);
        }

        public async Task<Plant> FindByIdAsync(int id)
        {
            return await _context.Plants.FindAsync(id);
        }

        public void Update(Plant plant)
        {
            _context.Plants.Update(plant);
        }

        public void Remove(Plant plant)
        {
            _context.Plants.Remove(plant);
        }

        public Task<Plant> FindByNameAsync(string name)
        {
            return _context.Plants.FirstOrDefaultAsync(p => p.Name == name);
        }

 
    }

}
