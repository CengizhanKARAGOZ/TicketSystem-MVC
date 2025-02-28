using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models;
using TicketSystem.Services;

namespace TicketSystem.Controllers;

public class CommentController: Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(int ticketId, string message)
    {
        var comment = new Comment
        {
            TicketId = ticketId,
            UserId = 1,
            Message = message
        };

        await _commentService.AddCommentAsync(comment);
        return RedirectToAction("Details", "Ticket", new { id = ticketId });
    }
}