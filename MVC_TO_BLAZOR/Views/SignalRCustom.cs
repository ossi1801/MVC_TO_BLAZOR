using Microsoft.AspNetCore.SignalR;

namespace MVC_TO_BLAZOR.Views;

public class ChatHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine(Context.ConnectionId);
        //SendMessage("xD", "xD");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine(exception.Message);
        return base.OnDisconnectedAsync(exception);
    }
    // public async Task SendMessage(string user, string message)
    // {
    //     await Clients.All.SendAsync("ReceiveMessage", user, message);
    // }
}

public class WriterHub : Hub<IWriterHub>
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"Writer_id: {Context.ConnectionId} connected");
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"Writer_id: {Context.ConnectionId} disconnected");
        //Console.WriteLine(exception.Message);
        return base.OnDisconnectedAsync(exception);
    }
     public async Task SendMessageToWriter(string id, string message)
     {
         await Clients.All.SendMessageToWriter( id, message);
     }
}
public interface IWriterHub
{
    Task SendMessageToWriter(string id, string message);
}