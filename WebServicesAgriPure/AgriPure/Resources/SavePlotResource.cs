using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WebServicesAgriPure.AgriPure.Resources;

[SwaggerSchema(Required = new[] { "Name" })]
public class SavePlotResource
{
    [SwaggerSchema("Name of Plot")]
    [Required]
    public string Name { get; set; }
    
    [SwaggerSchema("Area of Plot")]
    [Required]
    public double Area { get; set; }
    
    [SwaggerSchema("Detail of Plot")]
    [Required]
    public string Detail { get; set; }
    
    [SwaggerSchema("Quantity of Plot")]
    [Required]
    public int Quantity { get; set; }
}