using System.Text.Json.Serialization;
using WebServicesAgriPure.AgriPure.Domain.Models;

namespace WebServicesAgriPure.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }

    public List<UserPlant> SavedPlants { get; set; }
}