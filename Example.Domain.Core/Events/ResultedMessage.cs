using MediatR;

namespace Example.Domain.Core.Events
{
    public abstract class ResultedMessage<T> : Message, IRequest<T>
    {
    }
}