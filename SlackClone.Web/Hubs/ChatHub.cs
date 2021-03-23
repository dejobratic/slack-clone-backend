using Microsoft.AspNetCore.SignalR;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.UseCases;
using System;
using System.Collections.Generic;
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

        public async Task SendMessageToChannel(
            Guid groupId,
            SendMessageToChannelRequest request)
        {
            var message = await Execute<SendMessageToChannelRequest, MessageDto>(request);
            await Clients.Group(groupId.ToString()).SendAsync("ReceiveChannelMessage", message);
        }

        public async Task GetChannelMessages(
            GetChannelMessagesRequest request)
        {
            var messages = await Execute<GetChannelMessagesRequest, IEnumerable<MessageDto>>(request);
            await Clients.Caller.SendAsync("GetChannelMessages", messages);
        }

        public async Task CreateChannel(
            CreateChannelRequest request)
        {
            var channel = await Execute<CreateChannelRequest, ChannelDto>(request);
            await Clients.All.SendAsync("CreateChannel", channel);
        }

        public async Task GetSubscribedChannels(
            GetSubscribedChannelsRequest request)
        {
            var channels = await Execute<GetSubscribedChannelsRequest, IEnumerable<ChannelDto>>(request);
            await Clients.Caller.SendAsync("GetSubscribedChannels", channels);
        }

        public async Task JoinChannel(Guid groupId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupId.ToString());
        }

        private async Task<TOut> Execute<TIn, TOut>(TIn request)
            where TIn : IRequest
        {
            var command = _commandFactory.Create<TOut>(request);
            return await command.Execute();
        }
    }
}
