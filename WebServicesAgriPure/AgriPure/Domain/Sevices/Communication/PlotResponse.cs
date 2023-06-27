using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.Shared.Domain.Services;

namespace WebServicesAgriPure.AgriPure.Domain.Sevices.Communication;

public class PlotResponse : BaseResponse<Plot>
{
    public PlotResponse(string message): base(message)
    {
        
    }

    public PlotResponse(Plot plot) : base(plot)
    {
        
    }
    
}