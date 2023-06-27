using AutoMapper;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Resources;

namespace WebServicesAgriPure.AgriPure.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Plant, PlantResource>();
            CreateMap<Plot, PlotResource>();
        }
    }

}
