using WebServicesAgriPure.AgriPure.Domain.Models;

namespace WebServicesAgriPure.AgriPure.Domain.Repositories
{
    public interface IPlantRepository
    {
        Task<Plant> FindByNameAsync(string name);
        Task<IEnumerable<Plant>> ListAsync();
        Task<Plant> FindByIdAsync(int id);
        Task AddAsync(Plant plant);
        void Update(Plant plant);
        void Remove(Plant plant);
    }
}
