using AutoMapper;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Resources;

namespace WebServicesAgriPure.AgriPure.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap < SavePlantResource, Plant>();
            CreateMap<SavePlotResource, Plot>();
        }
    }
}
