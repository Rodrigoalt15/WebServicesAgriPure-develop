using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Domain.Repositories;
using WebServicesAgriPure.AgriPure.Domain.Sevices;
using WebServicesAgriPure.AgriPure.Domain.Sevices.Communication;

namespace WebServicesAgriPure.AgriPure.Services;

public class PlotService : IPlotService
{
    private readonly IPlotRepository _plotRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlotService(IPlotRepository plotRepository, IUnitOfWork unitOfWork)
    {
        this._plotRepository = plotRepository;
        this._unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<Plot>> ListAsync()
    {
        return await _plotRepository.ListAsync();
    }

    public async Task<PlotResponse> SaveAsync(Plot plot)
    {
        try
        {
            await _plotRepository.AddAsync(plot);
            await _unitOfWork.CompleteAsync();
            return new PlotResponse(plot);
        }
        catch (Exception e)
        {
            return new PlotResponse($"An error occurred while saving the Plot: {e.Message}");
        }
    }

    public async Task<PlotResponse> UpdateAsync(int id, Plot plot)
    {
        var existingPlot = await _plotRepository.FindByIdAsync(id);

        if (existingPlot == null)
            return new PlotResponse("Plot not found.");
        
        //Modify
        existingPlot.Name = plot.Name;
        existingPlot.Area = plot.Area;
        existingPlot.Detail = plot.Detail;
        existingPlot.Quantity = plot.Quantity;



        try
        {
            _plotRepository.Update(existingPlot);
            await _unitOfWork.CompleteAsync();

            return new PlotResponse(existingPlot);
        }
        catch (Exception e)
        {
            return new PlotResponse($"An error occurred while updating the Plot: {e.Message}");
        }
    }

    public async Task<PlotResponse> DeleteAsync(int id)
    {
        var existingPlot = await _plotRepository.FindByIdAsync(id);

        if (existingPlot == null)
            return new PlotResponse("Plot not found.");

        try
        {
            _plotRepository.Remove(existingPlot);
            await _unitOfWork.CompleteAsync();

            return new PlotResponse(existingPlot);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new PlotResponse($"An error occurred while deleting the plot: {e.Message}");
        }
    }
}