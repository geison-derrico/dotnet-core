using System;
using System.Linq;

namespace Example.Domain.Interfaces.ReadOnly
{
    public interface IRepositoryReadOnly<out TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(long id);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
    }
}
