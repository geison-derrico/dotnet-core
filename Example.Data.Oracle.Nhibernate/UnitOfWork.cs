using Example.Domain.Interfaces.Normalize;
using NHibernate;

namespace Example.Data.Oracle.Nhibernate
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITransaction _transaction;

        public UnitOfWork(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public bool Commit()
        {
            if (!_transaction.IsActive)
            {
                _transaction.Begin();
            }

            _transaction.Commit();
            return true;
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
