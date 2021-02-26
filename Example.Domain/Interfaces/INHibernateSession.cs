namespace Example.Domain.Interfaces
{
    public interface INHibernateSession
    {
        T Load<T>(object id);
    }
}