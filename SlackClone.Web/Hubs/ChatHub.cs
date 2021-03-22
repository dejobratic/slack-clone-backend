using Microsoft.AspNetCore.SignalR;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.UseCases;
using System;
using System.Threading.Tasks;

namespace SlackClone.Web.Hubs
{
    public class ChatHub :
        Hub
    {
        private readonly ICommandFactory _commandFactory;

        public ChatHub(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public async Task JoinMessageGroup(Guid groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());
        }

        public async Task SendMessageToGroup(
            Guid groupId,
            SendMessageToGroupChatRequest request)
        {
            var command = _commandFactory.Create<MessageDto>(request);
            var message = await command.Execute();

            await Clients.Group(groupId.ToString()).SendAsync("ReceiveMessage", message);
        }

        public async Task CreateChannel(
            CreateChannelRequest request)
        {
            var command = _commandFactory.Create<ChannelDto>(request);
            var channel = await command.Execute();

            await Clients.All.SendAsync("CreateChannel", channel);
        }
    }
}
