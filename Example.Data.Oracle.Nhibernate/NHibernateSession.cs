using Example.Domain.Interfaces;
using NHibernate;

namespace Example.Data.Oracle.Nhibernate
{
    public class NHibernateSession : INHibernateSession
    {
        private readonly ISession _session;

        public NHibernateSession(ISession session)
        {
            _session = session;
        }

        public T Load<T>(object id)
        {
            return _session.Load<T>(id);
        }
    }
}