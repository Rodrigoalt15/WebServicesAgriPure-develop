using Swashbuckle.AspNetCore.Annotations;

namespace WebServicesAgriPure.AgriPure.Resources
{
    public class PlantResource
    {
        [SwaggerSchema("Plant Identifier")]
        public int Id { get; set; }

        [SwaggerSchema("Plant Name")]
        public string Name { get; set; }

        [SwaggerSchema("Plant Image")]
        public string Image { get; set;}

        [SwaggerSchema("Plant Image2")]
        public string Image2 { get; set; }

        [SwaggerSchema("Plant Scientific Name")]
        public string Scientifistname { get; set; }

        [SwaggerSchema("Plant Variety")]
        public string Variety { get; set; }

        [SwaggerSchema("Plant Info Land Type")]
        public string InfolandType { get; set; }

        [SwaggerSchema("Plant Ph")]
        public float Ph { get; set; }

        [SwaggerSchema("Plant Info Distance Between")]
        public string InfoDistanceBetween { get; set; }

        [SwaggerSchema("Plant Distance Plants")]
        public string DistancePlants { get; set; }

        [SwaggerSchema("Plant Info Ideal Depth")]
        public string InfoIdealDepth { get; set; }

        [SwaggerSchema("Plant Depth")]
        public string Depth { get; set; }

        [SwaggerSchema("Plant Info Weather Conditions")]
        public string InfoWeatherConditions { get; set; }

        [SwaggerSchema("Plant Weather")]
        public string Weather { get; set; }

        [SwaggerSchema("Plant Info Fert Fumig")]
        public string InfoFertFumig { get; set; }

        [SwaggerSchema("Plant Intervale Fert")]
        public int IntervaleFert { get; set; }

        [SwaggerSchema("Plant Intervale Fumig")]
        public int IntervaleFumig { get; set; }

        [SwaggerSchema("Plant Save Plant")]
        public bool SavePlant { get; set; }

    }
}
