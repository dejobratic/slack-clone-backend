using SlackClone.Core.Models;

namespace SlackClone.Core.Services
{
    public interface IDateRangeProvider
    {
        DateRange Provide();
    }
}
