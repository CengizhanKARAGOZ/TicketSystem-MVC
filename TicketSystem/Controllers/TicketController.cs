using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.Controllers;

[Authorize]
public class TicketController:Controller
{
    private readonly ITicketService _ticketService;

    public TicketController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var userRole = User.FindFirstValue(ClaimTypes.Role);

        List<Ticket> tickets;

        if (userRole == "Admin")
        {
            tickets = await _ticketService.GetAllTicketsAsync();
        }
        else
        {
            tickets = await _ticketService.GetTicketsByUserIdAsync(int.Parse(userId));
        }

        if (tickets == null)
        {
            tickets = new List<Ticket>();
        }

        return View(tickets);
    }


    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Ticket ticket)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction("Login", "Auth");
        }

        ticket.CreatedBy = int.Parse(userId);
        ticket.Status = "Open";
        ticket.CreatedAt = DateTime.Now;
        
        if (ticket.Status.Length > 50)
        {
            ModelState.AddModelError("Status", "Durum en fazla 50 karakter olabilir.");
            return View(ticket);
        }

        await _ticketService.CreateTicketAsync(ticket);
        return RedirectToAction("Index");
    }
}