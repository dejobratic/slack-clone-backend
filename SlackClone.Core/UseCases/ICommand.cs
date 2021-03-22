using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public interface ICommand
    {
        Task Execute();
    }

    public interface ICommand<T>
    {
        Task<T> Execute();
    }
}
