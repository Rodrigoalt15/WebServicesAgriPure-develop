using WebServicesAgriPure.AgriPure.Domain.Models;

namespace WebServicesAgriPure.AgriPure.Domain.Repositories;

public interface IPlotRepository
{
    Task<IEnumerable<Plot>> ListAsync();
    Task AddAsync(Plot plot);
    Task<Plot> FindByIdAsync(int plotId);
    Task<Plot> FindByNameAsync(string name);
    void Update(Plot plot);
    void Remove(Plot plot);
}