namespace poc.trading.signalr.Hubs;

using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using poc.trading.signalr.Enities;
using poc.trading.signalr.Handler;

public class TradingHub : Hub
{
    private readonly IEnumerable<HubUser> users;
    private readonly ILogger<TradingHub> _logger;
    private readonly IClientHandler _clientHandler;

    public TradingHub(ILogger<TradingHub> logger, IClientHandler clientHandler)
    {
        _logger = logger;
        _clientHandler = clientHandler;
        users = clientHandler.Users;
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public void OnConnected(string userId)
    {
        ExceptionHandlers.HandleException(() =>
        {
            if (!users.Any(w => w.UserId.Equals(userId)))
            {
                var user = new HubUser
                {
                    UserId = userId,
                    ConnectionId = Context.ConnectionId
                };
                _clientHandler.AddUser(user);
                Console.WriteLine($"{userId} Connected with id : {Context.ConnectionId}");
            }
        }, _logger);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        ExceptionHandlers.HandleException(() =>
        {
            if (users.Any(x => x.ConnectionId == Context.ConnectionId))
            {
                var user = _clientHandler.RemoveUser(Context.ConnectionId);
                Console.WriteLine($"{user?.UserId} Connected with id : {Context.ConnectionId}");

            }
        }, _logger);
        await base.OnDisconnectedAsync(exception);
    }

    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}