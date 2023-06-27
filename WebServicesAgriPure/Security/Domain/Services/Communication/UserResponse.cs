using WebServicesAgriPure.Security.Domain.Models;

namespace WebServicesAgriPure.Security.Domain.Services.Communication
{
    public class UserResponse
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }
        public User User { get; protected set; }

        private UserResponse(bool success, string message, User user)
        {
            Success = success;
            Message = message;
            User = user;
        }

        // Constructor para respuestas exitosas
        public UserResponse(User user) : this(true, string.Empty, user)
        {
        }

        // Constructor para respuestas con error
        public UserResponse(string message) : this(false, message, null)
        {
        }
    }
}
