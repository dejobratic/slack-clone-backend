using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Extensions;
using SlackClone.Core.Models;
using SlackClone.Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public class GetChannelMessagesCommand :
        ICommand<IEnumerable<MessageDto>>
    {
        private readonly GetChannelMessagesRequest _request;
        private readonly IMessageRepository _messageRepo;

        public GetChannelMessagesCommand(
            GetChannelMessagesRequest request, 
            IMessageRepository messageRepo)
        {
            _request = request;
            _messageRepo = messageRepo;
        }

        public async Task<IEnumerable<MessageDto>> Execute()
        {
            MessageSpecification specification = 
                CreateSpecification();

            IEnumerable<Message> messages = 
                await _messageRepo.GetBy(specification);

            return messages.Select(m => m.ToContractModel());
        }

        private MessageSpecification CreateSpecification()
        {
            return new MessageSpecification
            {
                ChannelId = _request.ChannelId,
                PageSize = _request.PageSize,
                PageNumber = _request.PageNumber
            };
        }
    }
}
