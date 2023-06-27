using Microsoft.EntityFrameworkCore;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Domain.Repositories;
using WebServicesAgriPure.Shared.Persistence.Contexts;
using WebServicesAgriPure.Shared.Persistence.Repositories;

namespace WebServicesAgriPure.AgriPure.Repositories;

public class PlotRepository : BaseRepository, IPlotRepository
{
    public PlotRepository(AppDbContext context): base(context)
    {
    }

    public async Task<IEnumerable<Plot>> ListAsync()
    {
        return await _context.Plots.ToListAsync();
    }

    public async Task AddAsync(Plot plot)
    {
        await _context.Plots.AddAsync(plot);
    }

    public async Task<Plot> FindByIdAsync(int plotId)
    {
        return await _context.Plots
            .FirstOrDefaultAsync(p => p.Id == plotId);
        
    }

    public async Task<Plot> FindByNameAsync(string name)
    {
        return await _context.Plots
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public void Update(Plot plot)
    {
        _context.Plots.Update(plot);
    }

    public void Remove(Plot plot)
    {
        _context.Plots.Remove(plot);
    }
}