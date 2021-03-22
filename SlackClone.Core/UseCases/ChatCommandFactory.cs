using SlackClone.Contract.Requests;
using SlackClone.Core.Services;
using System;

namespace SlackClone.Core.UseCases
{
    public class ChatCommandFactory :
        ICommandFactory
    {
        private readonly ITimestampProvider _timestampProvider;
        private readonly IMessageRepository _messageRepo;
        private readonly IChannelRepository _channelRepo;

        public ChatCommandFactory(
            ITimestampProvider timestampProvider, 
            IMessageRepository messageRepo, 
            IChannelRepository channelRepo)
        {
            _timestampProvider = timestampProvider;
            _messageRepo = messageRepo;
            _channelRepo = channelRepo;
        }

        public ICommand Create(IRequest request)
        {
            throw new NotImplementedException();
        }

        public ICommand<T> Create<T>(IRequest request)
        {
            switch(request)
            {
                case SendMessageToGroupChatRequest sendMessageToGroupChatRequest:
                    return new SendMessageToGroupChatCommand(
                        sendMessageToGroupChatRequest,
                        _timestampProvider,
                        _messageRepo) as ICommand<T>;

                case CreateChannelRequest createChannelRequest:
                    return new CreateChannelCommand(
                        createChannelRequest,
                        _timestampProvider,
                        _channelRepo) as ICommand<T>;

                default:
                    throw new Exception("Unable to create chat command.");
            }
        }
    }
}
