using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace WebServicesAgriPure.AgriPure.Resources
{
    [SwaggerSchema(Required = new[] { "Name" })]
    public class SavePlantResource
    {
        [SwaggerSchema("Name of the plant")]
        [Required]
        public string Name { get; set; }

        [SwaggerSchema("Image of plant")]
        [Required]
        public string Image { get; set;}

        [SwaggerSchema("Image 2 of plant")]
        [Required]
        public string Image2 { get; set; }

        [SwaggerSchema("Scientific Name")]
        [Required]
        public string Scientifistname { get; set; }

        [SwaggerSchema("Variety")]
        [Required]
        public string Variety { get; set; }

        [SwaggerSchema("Info Land Type")]
        [Required]
        public string InfolandType { get; set; }

        [SwaggerSchema("Ph")]
        [Required]
        public float Ph { get; set; }

        [SwaggerSchema("Info Distance Between")]
        [Required]
        public string InfoDistanceBetween { get; set; }

        [SwaggerSchema("Distance Plants")]
        [Required]
        public string DistancePlants { get; set; }

        [SwaggerSchema("Info Ideal Depth")]
        [Required]
        public string InfoIdealDepth { get; set; }

        [SwaggerSchema("Depth")]
        [Required]
        public string Depth { get; set; }

        [SwaggerSchema("Info Weather Conditions")]
        [Required]
        public string InfoWeatherConditions { get; set; }

        [SwaggerSchema("Weather")]
        [Required]
        public string Weather { get; set; }

        [SwaggerSchema("Info Fert Fumig")]
        [Required]
        public string InfoFertFumig { get; set; }

        [SwaggerSchema("Intervale Fert")]
        [Required]
        public int IntervaleFert { get; set; }

        [SwaggerSchema("Intervale Fumig")]
        [Required]
        public int IntervaleFumig { get; set; }

        [SwaggerSchema("Save Plant")]
        public bool SavePlant { get; set; }

    }
}
