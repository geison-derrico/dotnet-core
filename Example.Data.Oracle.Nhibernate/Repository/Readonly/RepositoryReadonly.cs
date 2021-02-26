using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Example.Domain.Interfaces.ReadOnly;
using NHibernate;

namespace Example.Data.Oracle.Nhibernate.Repository.Readonly
{
    public class RepositoryReadOnly<TEntity> : IRepositoryReadOnly<TEntity> where TEntity : class
    {
        protected readonly ISession Session;

        public RepositoryReadOnly(ISession session)
        {
            Session = session;
        }

        public virtual TEntity GetById(long id)
        {
            return Session.Get<TEntity>(id);
        }

        public TEntity GetById(int id)
        {
            return Session.Get<TEntity>(id);
        }


        public virtual IQueryable<TEntity> GetAll()
        {
            return Session.Query<TEntity>();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Session.Query<TEntity>().Where(predicate).AsEnumerable();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
