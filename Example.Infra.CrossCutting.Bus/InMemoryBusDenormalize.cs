using System.Threading.Tasks;
using Example.Domain.Core.Bus.Denormalize;
using Example.Domain.Core.Commands;
using MediatR;

namespace Example.Infra.CrossCutting.Bus
{
    public sealed class InMemoryBusDenormalize : IMediatorHandlerDenormalize
    {
        private readonly IMediator _mediator;

        public InMemoryBusDenormalize(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendDenormalize<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
