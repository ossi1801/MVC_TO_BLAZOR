using Microsoft.AspNetCore.SignalR;

namespace MVC_TO_BLAZOR.Views;

public class ChatHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine(Context.ConnectionId);
        SendMessage("xD", "xD");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine(exception.Message);
        return base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public void xd()
    {
        
        Clients.All.SendAsync("ReceiveMessage", "user", "message");
    }
}
