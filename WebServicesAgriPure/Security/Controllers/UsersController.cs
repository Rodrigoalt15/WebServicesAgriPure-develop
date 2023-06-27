using AutoMapper;
using WebServicesAgriPure.Security.Authorization.Attributes;
using Microsoft.AspNetCore.Mvc;
using WebServicesAgriPure.Security.Domain.Models;
using WebServicesAgriPure.Security.Domain.Services;
using WebServicesAgriPure.Security.Resources;
using WebServicesAgriPure.Security.Services.Communication;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.AgriPure.Resources;

namespace WebServicesAgriPure.Security.Controllers;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [AllowAnonymous]
    [HttpPost("sign-in")]
    public async Task<IActionResult> Authenticate(AuthenticateRequest request)
    {
        var response = await _userService.Authenticate(request);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("sign-up")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.RegisterAsync(request);
        return Ok(new { message = "Registration successful" });
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, 
            IEnumerable<UserResource>>(users);
        return Ok(resources);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(user);
        return Ok(resource);
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateRequest request)
    {
        await _userService.UpdateAsync(id, request);
        return Ok(new { message = "User updated successfully" });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);
        return Ok(new { message = "User deleted successfully" });
    }
    [HttpPost("{userId}/plants/{plantId}")]
    public async Task<IActionResult> AddPlantToCollection(int userId, int plantId)
    {
        var result = await _userService.AddPlantToCollectionAsync(userId, plantId);
        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.User);
        return Ok(userResource);
    }

    [HttpDelete("{userId}/plants/{plantId}")]
    public async Task<IActionResult> RemovePlantFromCollection(int userId, int plantId)
    {
        var result = await _userService.RemovePlantFromCollectionAsync(userId, plantId);
        if (!result.Success)
            return BadRequest(result.Message);

        var userResource = _mapper.Map<User, UserResource>(result.User);
        return Ok(userResource);
    }

    [HttpGet("{userId}/plants")]
    public async Task<IActionResult> GetSavedPlantsByUserId(int userId)
    {
        var plants = await _userService.GetSavedPlantsByUserIdAsync(userId);
        var plantResources = _mapper.Map<IEnumerable<Plant>, IEnumerable<PlantResource>>(plants);
        return Ok(plantResources);
    }
}