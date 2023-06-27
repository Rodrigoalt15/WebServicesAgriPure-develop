using AutoMapper;
using WebServicesAgriPure.Security.Domain.Models;
using WebServicesAgriPure.Security.Resources;
using WebServicesAgriPure.Security.Services.Communication;

namespace WebServicesAgriPure.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();

    }
}