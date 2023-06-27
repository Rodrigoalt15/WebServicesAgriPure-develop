namespace WebServicesAgriPure.AgriPure.Domain.Models
{
    public class Plant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Image2 { get; set; }
        public string Scientifistname { get; set; }
        public string Variety { get; set; }
        public string InfolandType { get; set; }
        public float Ph { get; set; }
        public string InfoDistanceBetween { get; set; }
        public string DistancePlants { get; set; }
        public string InfoIdealDepth { get; set; }
        public string Depth { get; set; }
        public string InfoWeatherConditions { get; set; }
        public string Weather { get; set; }
        public string InfoFertFumig { get; set; }
        public int IntervaleFert { get; set; }
        public int IntervaleFumig { get; set; }
        public bool SavePlant { get; set; }
        public List<UserPlant> SavedByUsers { get; set; }

    }
}
