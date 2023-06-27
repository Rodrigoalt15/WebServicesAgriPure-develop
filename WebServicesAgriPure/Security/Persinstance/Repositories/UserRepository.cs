using Microsoft.EntityFrameworkCore;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.Security.Domain.Models;
using WebServicesAgriPure.Security.Domain.Repositories;
using WebServicesAgriPure.Shared.Persistence.Contexts;
using WebServicesAgriPure.Shared.Persistence.Repositories;

namespace WebServicesAgriPure.Security.Persinstance.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context): base(context)
    {
        
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }
    public async Task<User> FindByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }
    public async Task<User> FindByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(x => 
            x.Username == username);
    }
    public bool ExistsByUsername(string username)
    {
        return _context.Users.Any(x => x.Username == username);
    }
    public User FindById(int id)
    {
        return _context.Users.Find(id);
    }
    public void Update(User user)
    {
        _context.Users.Update(user);
    }
    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task AddPlantToCollection(UserPlant userPlant)
    {
        await _context.UserPlants.AddAsync(userPlant);
    }

    public void RemovePlantFromCollection(UserPlant userPlant)
    {
        _context.UserPlants.Remove(userPlant);
    }

    public async Task<IEnumerable<Plant>> GetSavedPlantsByUserId(int userId)
    {
        return await _context.UserPlants
            .Where(up => up.UserId == userId)
            .Select(up => up.Plant)
            .ToListAsync();
    }

    public async Task<UserPlant> GetUserPlantAsync(int userId, int plantId)
    {
        return await _context.UserPlants.FirstOrDefaultAsync(up => up.UserId == userId && up.PlantId == plantId);
    }
}