using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models;

public class Ticket
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    public string Description { get; set; }

    [MaxLength(50)]
    public string Status { get; set; } = "Open";

    [ForeignKey("User")]
    public int CreatedBy { get; set; }
    
    public User User { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public List<Comment> Comments { get; set; } = new List<Comment>();
}