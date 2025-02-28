using TicketSystem.Models;

namespace TicketSystem.Services;

public interface ICommentService
{
    Task<List<Comment>> GetCommentsByTicketIdAsync(int ticketId);
    Task AddCommentAsync(Comment comment);
}