using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Domain.Sevices;
using WebServicesAgriPure.AgriPure.Domain.Sevices.Communication;
using WebServicesAgriPure.AgriPure.Resources;
using WebServicesAgriPure.Shared.Extensions;

namespace WebServicesAgriPure.AgriPure.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class PlantController : ControllerBase
    {
        private readonly IPlantService _plantService;
        private readonly IMapper _mapper;

        public PlantController(IPlantService plantService, IMapper mapper)
        {
            _plantService = plantService;
            _mapper = mapper;
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult> FindByName(string name)
        {
            var result = await _plantService.FindByNameAsync(name);
            if (!result.Success)
                return BadRequest(result.Message);

            var plantResource = _mapper.Map<Plant, PlantResource>(result.Resource);
            return Ok(plantResource);
        }

        [HttpGet]
        public async Task<IEnumerable<PlantResource>> ListAsync()
        {
            var plants = await _plantService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Plant>, IEnumerable<PlantResource>>(plants);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByIdAsync(int id)
        {
           var result = await _plantService.FindByIdAsync(id);
            if(!result.Success)
                return BadRequest(result.Message);

            var plantResource = _mapper.Map<Plant, PlantResource>(result.Resource);
            return Ok(plantResource);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PlantResource), 201)]
        [ProducesResponseType(typeof(List<string>), 400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] SavePlantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var plant = _mapper.Map<SavePlantResource, Plant>(resource);
            var result = await _plantService.SaveAsync(plant);

            if (!result.Success)
                return BadRequest(result.Message);

            var plantResource = _mapper.Map<Plant, PlantResource>(result.Resource);
            return Ok(plantResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SavePlantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var plant = _mapper.Map<SavePlantResource, Plant>(resource);
            var result = await _plantService.UpdateAsync(id, plant);

            if (!result.Success)
                return BadRequest(result.Message);

            var plantResource = _mapper.Map<Plant, PlantResource>(result.Resource);
            return Ok(plantResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _plantService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var plantResource = _mapper.Map<Plant, PlantResource>(result.Resource);
            return Ok(plantResource);
        }

    }


}
