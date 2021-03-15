using Microsoft.AspNetCore.SignalR;
using SlackClone.Web.Hubs.Clients;

namespace SlackClone.Web.Hubs
{
    public class ChannelHub :
        Hub<IChannelClient>
    {
    }
}
