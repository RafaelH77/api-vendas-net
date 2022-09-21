using CleanNet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanNet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessagesController : ControllerBase
{
    private readonly IMessageService _messageService;
    public MessagesController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost]
    public ActionResult Post([FromBody] String message)
    {
        _messageService.Publish(message);
        
        return Ok(message);
    }

}
