using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVC_TO_BLAZOR.Models;
using MVC_TO_BLAZOR.Views;
namespace MVC_TO_BLAZOR.Controllers;

public class JavascriptController 
{
    private readonly IHubContext<ChatHub> _hubContext;
    public JavascriptController(IHubContext<ChatHub> hubContext)
    {
        _hubContext = hubContext;
    }
    public async Task BroadcastMessage(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage","SERVER SAYS:" , message);
    }
}