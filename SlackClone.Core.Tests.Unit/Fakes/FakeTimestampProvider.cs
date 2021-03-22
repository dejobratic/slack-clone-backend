using SlackClone.Core.Services;
using System;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public class FakeTimestampProvider :
        ITimestampProvider
    {
        public DateTimeOffset Returns { get; set; }

        public DateTimeOffset Provide()
            => Returns;
    }
}
