using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Domain.Repositories;
using WebServicesAgriPure.AgriPure.Domain.Sevices;
using WebServicesAgriPure.AgriPure.Domain.Sevices.Communication;

namespace WebServicesAgriPure.AgriPure.Services
{
    public class PlantService: IPlantService
    {
        private readonly IPlantRepository _plantRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PlantService(IPlantRepository plantRepository, IUnitOfWork unitOfWork)
        {
            _plantRepository = plantRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Plant>> ListAsync()
        {
            return await _plantRepository.ListAsync();
        }

        public async Task<PlantResponse> SaveAsync(Plant plant)
        {
            try
            {
                await _plantRepository.AddAsync(plant);
                await _unitOfWork.CompleteAsync();

                return new PlantResponse(plant);
            }
            catch (Exception ex)
            {
                return new PlantResponse($"An error occurred when saving the plant: {ex.Message}");
            }
        }

        public async Task<PlantResponse> UpdateAsync(int id, Plant plant)
        {
            var existingPlant = await _plantRepository.FindByIdAsync(id);

            if (existingPlant == null)
                return new PlantResponse("Plant not found.");

            existingPlant.Name = plant.Name;

            try
            {
                _plantRepository.Update(existingPlant);
                await _unitOfWork.CompleteAsync();

                return new PlantResponse(existingPlant);
            }
            catch (Exception ex)
            {
                return new PlantResponse($"An error occurred when updating the plant: {ex.Message}");
            }
        }

        public async Task<PlantResponse> DeleteAsync(int id)
        {
            var existingPlant = await _plantRepository.FindByIdAsync(id);

            if (existingPlant == null)
                return new PlantResponse("Plant not found.");

            try
            {
                _plantRepository.Remove(existingPlant);
                await _unitOfWork.CompleteAsync();

                return new PlantResponse(existingPlant);
            }
            catch (Exception ex)
            {
                return new PlantResponse($"An error occurred when deleting the plant: {ex.Message}");
            }
        }

        public async Task<PlantResponse> FindByNameAsync(string name)
        {
            var existingPlant = await _plantRepository.FindByNameAsync(name);

            if (existingPlant == null)
                return new PlantResponse("Plant not found.");

            try
            {
                return new PlantResponse(existingPlant);
            }
            catch (Exception ex)
            {
                return new PlantResponse($"An error occurred when retrieving the plant: {ex.Message}");
            }
        }

        public async Task<PlantResponse> FindByIdAsync(int id)
        {
            var existingPlant = await _plantRepository.FindByIdAsync(id);

            if (existingPlant == null)
                return new PlantResponse("Plant not found.");

            try
            {
                return new PlantResponse(existingPlant);
            }
            catch (Exception ex)
            {
                return new PlantResponse($"An error occurred when retrieving the plant: {ex.Message}");
            }
        }
    }
}
