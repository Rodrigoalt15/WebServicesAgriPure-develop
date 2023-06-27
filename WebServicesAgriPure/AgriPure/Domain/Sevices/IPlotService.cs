using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Domain.Sevices.Communication;

namespace WebServicesAgriPure.AgriPure.Domain.Sevices;

public interface IPlotService
{
    Task<IEnumerable<Plot>> ListAsync();
    Task<PlotResponse> SaveAsync(Plot plot);
    Task<PlotResponse> UpdateAsync(int id, Plot plot);
    Task<PlotResponse> DeleteAsync(int id);
}