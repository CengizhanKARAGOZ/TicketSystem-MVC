using TicketSystem.Models;

namespace TicketSystem.Services;

public interface IAuthService
{
    Task<User?> AuthenticateAsync(string email, string password);
    Task<bool> RegisterAsync(User user);
}