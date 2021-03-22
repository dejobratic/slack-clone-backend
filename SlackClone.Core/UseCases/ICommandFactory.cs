using SlackClone.Contract.Requests;

namespace SlackClone.Core.UseCases
{
    public interface ICommandFactory
    {
        ICommand Create(IRequest request);
        ICommand<T> Create<T>(IRequest request);
    }
}
