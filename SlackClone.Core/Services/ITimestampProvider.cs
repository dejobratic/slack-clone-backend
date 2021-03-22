using System;

namespace SlackClone.Core.Services
{
    public interface ITimestampProvider
    {
        DateTimeOffset Provide();
    }
}
