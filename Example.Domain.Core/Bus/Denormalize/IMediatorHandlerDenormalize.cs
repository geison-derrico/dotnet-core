using System.Threading.Tasks;
using Example.Domain.Core.Commands;

namespace Example.Domain.Core.Bus.Denormalize
{
    public interface IMediatorHandlerDenormalize
    {
        Task SendDenormalize<T>(T command) where T : Command;
    }
}
