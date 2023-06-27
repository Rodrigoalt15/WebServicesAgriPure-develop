using Swashbuckle.AspNetCore.Annotations;

namespace WebServicesAgriPure.AgriPure.Resources;

public class PlotResource
{
    [SwaggerSchema("Plot Identifier")]
    public int Id { get; set; }
    
    [SwaggerSchema("Plot Name")]
    public string Name { get; set; }
    
    [SwaggerSchema("Plot Area")]
    public double Area { get; set; }
    
    [SwaggerSchema("Plot Detail")]
    public string Detail { get; set; }
    
    [SwaggerSchema("Plot Quantity")]
    public int Quantity { get; set; }
}