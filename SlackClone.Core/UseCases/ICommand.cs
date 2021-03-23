using System.Threading.Tasks;

namespace SlackClone.Core.UseCases
{
    public interface ICommand<T>
    {
        Task<T> Execute();
    }
}
