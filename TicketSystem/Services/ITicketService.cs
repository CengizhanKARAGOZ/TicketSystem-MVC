using TicketSystem.Models;

namespace TicketSystem.Services;

public interface ITicketService
{ 
    Task<List<Ticket>> GetAllTicketsAsync();
    Task<List<Ticket>> GetTicketsByUserIdAsync(int userId);
    Task<Ticket> GetTicketByIdAsync(int id);
    Task CreateTicketAsync(Ticket ticket);
    Task UpdateTicketAsync(Ticket ticket);
    Task DeleteTicketAsync(int id);
}