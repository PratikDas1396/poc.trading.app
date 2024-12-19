using poc.trading.signalr.Enities;

namespace poc.trading.signalr.Handler;

public interface IClientHandler
{
    List<HubUser> Users { get; set; }
    void AddUser(HubUser user);
    HubUser RemoveUser(string connectionId);
}