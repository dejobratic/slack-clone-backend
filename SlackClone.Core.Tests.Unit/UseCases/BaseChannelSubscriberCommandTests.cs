using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlackClone.Contract.Dtos;
using SlackClone.Contract.Requests;
using SlackClone.Core.UseCases;
using System;
using System.Threading.Tasks;

namespace SlackClone.Core.Tests.Unit.UseCases
{
    [TestClass]
    [TestCategory("Unit")]
    public abstract class BaseChannelSubscriberCommandTests<T>
        where T : BaseChannelSubscriberRequest
    {
        protected BaseChannelSubscriberCommand<T> _sut;

        protected readonly Guid _expectedChannelId = Guid.NewGuid();
        protected readonly string _expectedChannelName = "Some name!";
        protected readonly string _expectedChannelDescription = "Some description!";
        protected readonly Guid _expectedChannelCreatorId = Guid.NewGuid();
        protected readonly DateTimeOffset _expectedChannelCreatedAt = DateTimeOffset.UtcNow;

        [TestInitialize]
        public void Initialize()
        {
            CreateSut();
        }

        [TestMethod]
        public void Able_to_create_instance()
        {
        }

        [TestMethod]
        public async Task Able_to_execute_command()
        {
            ChannelDto actual = await _sut.Execute();
            ChannelDto expected = CreateExpected();

            actual.Should().BeEquivalentTo(expected);
        }

        protected abstract void CreateSut();

        protected abstract ChannelDto CreateExpected();
    }
}
