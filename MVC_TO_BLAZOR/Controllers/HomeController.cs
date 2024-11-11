using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MVC_TO_BLAZOR.Models;
using MVC_TO_BLAZOR.Views;
namespace MVC_TO_BLAZOR.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHubContext<ChatHub> _hubContext;
    public HomeController(ILogger<HomeController> logger, IHubContext<ChatHub> hubContext)
    {
        _logger = logger;
        _hubContext = hubContext;
    }
    //Ei toimi ? --> Controller ei oo service ?
    public async Task BroadcastMessage(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage","SERVER SAYS:" , message);
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


}