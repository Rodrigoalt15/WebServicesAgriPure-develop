using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.Security.Domain.Models;
using WebServicesAgriPure.Security.Domain.Services.Communication;
using WebServicesAgriPure.Security.Services.Communication;

namespace WebServicesAgriPure.Security.Domain.Services;

public interface IUserService
{
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, UpdateRequest model);
    Task DeleteAsync(int id);

    Task<UserResponse> AddPlantToCollectionAsync(int userId, int plantId);
    Task<UserResponse> RemovePlantFromCollectionAsync(int userId, int plantId);
    Task<IEnumerable<Plant>> GetSavedPlantsByUserIdAsync(int userId);

}