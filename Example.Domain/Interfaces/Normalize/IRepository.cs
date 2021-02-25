using Example.Domain.Interfaces.ReadOnly;

namespace Example.Domain.Interfaces.Normalize
{
    public interface IRepository<TEntity> : IRepositoryReadOnly<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(long id);
    }
}
