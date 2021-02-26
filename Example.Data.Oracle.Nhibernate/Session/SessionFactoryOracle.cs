using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Example.Data.Oracle.Nhibernate.Listeners;
using Example.Domain.Interfaces;
using NHibernate;
using NHibernate.Event;

namespace Example.Data.Oracle.Nhibernate.Session
{
    public class SessionFactoryOracle
    {
        public static ISessionFactory CreateSessionFactory(string connectionString, IUsuario usuario)
        {
            FluentConfiguration config = Fluently.Configure();
            config.BuildConfiguration();

            config.Database(OracleManagedDataClientConfiguration.Oracle10.ConnectionString(connectionString).ShowSql());

            //Mappings here!
            config.Mappings(m => m.FluentMappings.AddFromAssembly(typeof(UnitOfWork).Assembly));

            config.ExposeConfiguration(cfg =>
            {
                var auditLogListener = new AuditLogListener(usuario);
                cfg.SetListener(ListenerType.PreInsert, auditLogListener);
                cfg.SetListener(ListenerType.PreUpdate, auditLogListener);
            });

            return config.BuildSessionFactory();
        }
    }
}
