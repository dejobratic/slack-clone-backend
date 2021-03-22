using System;

namespace SlackClone.Core.Services
{
    public class TimestampProvider :
        ITimestampProvider
    {
        public DateTimeOffset Provide()
            => DateTimeOffset.UtcNow;
    }
}
