using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Domain.Sevices.Communication;

namespace WebServicesAgriPure.AgriPure.Domain.Sevices
{
    public interface IPlantService
    {
        Task<PlantResponse> FindByNameAsync(string name);

        Task<PlantResponse> SaveAsync(Plant plant);

        Task<PlantResponse> FindByIdAsync(int id);

        Task<PlantResponse> UpdateAsync(int id, Plant plant);
        
        Task<PlantResponse> DeleteAsync(int id);

        Task<IEnumerable<Plant>> ListAsync();
    }
}
