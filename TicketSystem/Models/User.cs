using System.ComponentModel.DataAnnotations;

namespace TicketSystem.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string PasswordHash { get; set; }

    public string Role { get; set; } = "User";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}