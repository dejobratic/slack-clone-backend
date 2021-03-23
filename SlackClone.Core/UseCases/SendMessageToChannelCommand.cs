using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System;
using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public class SendMessageToChannelCommand :
        ICommand<MessageDto>
    {
        private readonly SendMessageToChannelRequest _request;
        private readonly ITimestampProvider _timestampProvider;
        private readonly IMessageRepository _messageRepo;

        public SendMessageToChannelCommand(
            SendMessageToChannelRequest request, 
            ITimestampProvider timestampProvider, 
            IMessageRepository messageRepo)
        {
            _request = request;
            _timestampProvider = timestampProvider;
            _messageRepo = messageRepo;
        }

        public async Task<MessageDto> Execute()
        {
            Message message = CreateMessage();
            await _messageRepo.Save(message);

            return message.ToContractModel();
        }

        private Message CreateMessage()
        {
            return new Message
            {
                Id = Guid.NewGuid(),
                Text = _request.Text,
                ChannelId = _request.ChannelId,
                CreatorId = _request.CreatorId,
                CreatedAt = _timestampProvider.Provide()
            };
        }
    }
}
