using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.Security.Domain.Models;

namespace WebServicesAgriPure.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(int id);
    Task<User> FindByUsernameAsync(string username);
    public bool ExistsByUsername(string username);
    User FindById(int id);
    void Update(User user);
    void Remove(User user);

    Task AddPlantToCollection(UserPlant userPlant);  
    void RemovePlantFromCollection(UserPlant userPlant); 
    Task<IEnumerable<Plant>> GetSavedPlantsByUserId(int userId);

    Task<UserPlant> GetUserPlantAsync(int userId, int plantId);
}