using System;

namespace SlackClone.Core.Models
{
    public class DateRange
    {
        public DateTimeOffset From { get; }
        public DateTimeOffset To { get; }

        public DateRange(
            DateTimeOffset from,
            DateTimeOffset to)
        {
            From = from;
            To = to;

            // TODO: add validation logic
        }
    }
}
