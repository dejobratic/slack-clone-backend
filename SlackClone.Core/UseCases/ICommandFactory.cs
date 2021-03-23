using SlackClone.Contract.Requests;

namespace SlackClone.Core.UseCases
{
    public interface ICommandFactory
    {
        ICommand<T> Create<T>(IRequest request);
    }
}
