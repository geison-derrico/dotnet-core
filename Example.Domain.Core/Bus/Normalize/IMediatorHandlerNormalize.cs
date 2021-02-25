using System.Threading.Tasks;
using Example.Domain.Core.Commands;
using Example.Domain.Core.Events;

namespace Example.Domain.Core.Bus.Normalize
{
    public interface IMediatorHandlerNormalize
    {
        Task SendCommand<T>(T command) where T : Command;
        Task<TResult> SendCommand<T, TResult>(T command) where T : ResultedCommand<TResult>;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
