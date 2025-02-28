using Microsoft.EntityFrameworkCore;
using TicketSystem.Data;
using TicketSystem.Models;

namespace TicketSystem.Services;

public class AuthService:IAuthService
{
    private readonly ApplicationDbContext _context;

    public AuthService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<User?> AuthenticateAsync(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == password);
    }

    public async Task<bool> RegisterAsync(User user)
    {
        if (await _context.Users.AnyAsync(u => u.Email == user.Email))
            return false;

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }
}