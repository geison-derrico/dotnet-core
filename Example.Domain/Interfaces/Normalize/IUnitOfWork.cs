using System;

namespace Example.Domain.Interfaces.Normalize
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
