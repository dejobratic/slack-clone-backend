using SlackClone.Core.Models;
using SlackClone.Core.Services;

namespace SlackClone.Core.Tests.Unit.Fakes
{
    public class FakeDateRangeProvider :
        IDateRangeProvider
    {
        public DateRange Returns { get; set; }

        public DateRange Provide()
            => Returns;
    }
}
