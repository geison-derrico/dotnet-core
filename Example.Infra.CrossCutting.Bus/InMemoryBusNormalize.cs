using System.Threading.Tasks;
using Example.Domain.Core.Bus.Normalize;
using Example.Domain.Core.Commands;
using Example.Domain.Core.Events;
using MediatR;

namespace Example.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBusNormalize : IMediatorHandlerNormalize
    {
        private readonly IMediator _mediator;

        public InMemoryBusNormalize(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
        public Task<TResult> SendCommand<T, TResult>(T command) where T : ResultedCommand<TResult>
        {
            return _mediator.Send<TResult>(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}
