using SlackClone.Core.Models;

namespace SlackClone.Core.Services
{
    public class DateRangeProvider :
        IDateRangeProvider
    {
        private readonly DateRange _dateRange;

        public DateRangeProvider(
            DateRange dateRange)
        {
            _dateRange = dateRange;
        }

        public DateRange Provide()
            => _dateRange;
    }
}
