using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.Models;
using SlackClone.Core.Tests.Unit.Fakes;
using SlackClone.Core.UseCases;
using System;
using System.Collections.Generic;

namespace SlackClone.Core.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public class AddSubscribersToChannelCommandTests :
        BaseChannelSubscriberCommandTests<AddSubscriberToChannelRequest>
    {
        protected readonly Guid _newSubscriberId = Guid.NewGuid();

        protected override void CreateSut()
        {
            _sut = new AddSubscriberToChannelCommand(
                new AddSubscriberToChannelRequest
                {
                    SubscriberId = _newSubscriberId
                },
                new FakeChannelRepository
                {
                    Returns = new[]
                    {
                        new Channel
                        {
                            Id = _expectedChannelId,
                            Name = _expectedChannelName,
                            Description = _expectedChannelDescription,
                            CreatedAt = _expectedChannelCreatedAt,
                            CreatorId = _expectedChannelCreatorId,
                            SubscriberIds = new List<Guid>
                            {
                                _expectedChannelCreatorId
                            }
                        }
                    }
                });
        }

        protected override ChannelDto CreateExpected()
        {
            return new ChannelDto
            {
                Id = _expectedChannelId,
                Name = _expectedChannelName,
                Description = _expectedChannelDescription,
                CreatorId = _expectedChannelCreatorId,
                SubscriberIds = new Guid[]
                {
                    _expectedChannelCreatorId,
                    _newSubscriberId
                }
            };
        }
    }
}
