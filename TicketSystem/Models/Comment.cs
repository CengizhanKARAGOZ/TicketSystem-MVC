using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSystem.Models;

public class Comment
{
    public int Id { get; set; }

    [ForeignKey("Ticket")]
    public int TicketId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    public string Message { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Ticket Ticket { get; set; }
    
    public User User { get; set; }
}