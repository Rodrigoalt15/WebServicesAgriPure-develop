using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Domain.Sevices;
using WebServicesAgriPure.AgriPure.Mapping;
using WebServicesAgriPure.AgriPure.Resources;
using WebServicesAgriPure.Shared.Extensions;

namespace WebServicesAgriPure.AgriPure.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class PlotsController : ControllerBase
{
    private readonly IPlotService _plotService;
    private readonly IMapper _mapper;

    public PlotsController(IPlotService plot, IMapper mapper)
    {
        this._mapper = mapper;
        this._plotService   = plot;

    }

    [HttpGet]
    public async Task<IEnumerable<PlotResource>> GetAllAsync()
    {
        var plots = await _plotService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Plot>, IEnumerable<PlotResource>>(plots);

        return resources;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SavePlotResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var plot = _mapper.Map<SavePlotResource, Plot>(resource);

        var result = await _plotService.SaveAsync(plot);

        if (!result.Success)
            return BadRequest(result.Message);

        var plotResource = _mapper.Map<Plot, PlotResource>(result.Resource);

        return Ok(plotResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SavePlotResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var plot = _mapper.Map<SavePlotResource, Plot>(resource);

        var result = await _plotService.UpdateAsync(id, plot);

        if (!result.Success)
            return BadRequest(result.Message);

        var plotResource = _mapper.Map<Plot, PlotResource>(result.Resource);

        return Ok(plotResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _plotService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var plotResource = _mapper.Map<Plot, PlotResource>(result.Resource);

        return Ok(plotResource);
    }
}