using NHibernate.Event;
using NHibernate.Persister.Entity;
using Example.Domain.Interfaces;
using Example.Domain.Models.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example.Data.Oracle.Nhibernate.Listeners
{
    public class AuditLogListener : IPreInsertEventListener, IPreUpdateEventListener
    {
        private readonly IUsuario _usuario;

        public AuditLogListener(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public bool OnPreInsert(PreInsertEvent @event)
        {
            if (!(@event.Entity is IEntity))
                return false;

            var dateNow = DateTime.Now;

            Set(@event.Persister, @event.State, "DataHoraInclusao", dateNow);
            Set(@event.Persister, @event.State, "DataHoraAlteracao", dateNow);

            //if (_usuario != null && !string.IsNullOrEmpty(_usuario.IdOperador))
            //{
            //    Set(@event.Persister, @event.State, "IdOperador", _usuario.IdOperador);
            //}

            return false;
        }

        public Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            return Task.FromResult(false);
        }

        public bool OnPreUpdate(PreUpdateEvent @event)
        {
            if (!(@event.Entity is IEntity))
                return false;

            var dateNow = DateTime.Now;

            if (Get(@event.Persister, @event.State, "DataHoraInclusao") == null)
            {
                Set(@event.Persister, @event.State, "DataHoraInclusao", dateNow);
            }

            Set(@event.Persister, @event.State, "DataHoraAlteracao", dateNow);

            //if (_usuario != null && !string.IsNullOrEmpty(_usuario.IdOperador))
            //{
            //    Set(@event.Persister, @event.State, "IdOperador", _usuario.IdOperador);
            //}

            return false;
        }

        public Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            return Task.FromResult(false);
        }

        private static void Set(IEntityPersister persister, object[] state, string propertyName, object value)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);
            if (index == -1)
            {
                return;
            }
            state[index] = value;
        }

        private static object Get(IEntityPersister persister, object[] state, string propertyName)
        {
            var index = Array.IndexOf(persister.PropertyNames, propertyName);

            return index == -1 ? null : state[index];
        }
    }
}
