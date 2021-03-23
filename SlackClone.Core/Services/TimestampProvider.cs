using System;

namespace SlackClone.Core.Services
{
    public class TimestampProvider :
        ITimestampProvider
    {
        private readonly DateTimeOffset _timestamp;

        public TimestampProvider(
            DateTimeOffset timestamp)
        {
            _timestamp = timestamp;
        }

        public DateTimeOffset Provide()
            => _timestamp;
    }
}
