using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.Shared.Domain.Services;

namespace WebServicesAgriPure.AgriPure.Domain.Sevices.Communication
{
    public class PlantResponse : BaseResponse<Plant>
    {
        public PlantResponse(Plant resource) : base(resource)
        {
        }

        public PlantResponse(string message) : base(message)
        {
        }
    }
}
