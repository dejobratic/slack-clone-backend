using System;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public static class DateTimeProvider
    {
        public static readonly DateTime Today
            = DateTime.UtcNow.Date;

        public static readonly DateTime Tomorrow
            = Today.AddDays(1);

        public static readonly DateTime MinValue
            = DateTime.MinValue;
    }
}
