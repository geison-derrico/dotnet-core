using System;
using System.Linq;
using System.Linq.Expressions;
using Example.Domain.Interfaces;
using Example.Domain.Interfaces.Normalize;
using Example.Domain.Models.Interfaces;
using NHibernate;

namespace Example.Data.Oracle.Nhibernate.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ISession _session;
        private readonly IUsuario _usuario;

        public Repository(ISession session, IUsuario usuario)
        {
            _session = session;
            _usuario = usuario;
        }

        public virtual void Add(TEntity obj)
        {
            if (obj is IEntidadeAuditavel entidadeAuditavel)
            {
                entidadeAuditavel.DataHoraInclusao = DateTime.Now;
                entidadeAuditavel.DataHoraAlteracao = DateTime.Now;
            }

            if (obj is IEntidadeAuditavelPessoa entidadeAuditavelPessoa)
            {
                if (String.IsNullOrEmpty(entidadeAuditavelPessoa.IdOperador))
                    entidadeAuditavelPessoa.IdOperador = _usuario.IdOperador;
            }

            _session.Save(obj);
        }

        public virtual TEntity GetById(int id)
        {
            return _session.Get<TEntity>(id);
        }

        public TEntity GetById(long id)
        {
            return _session.Get<TEntity>(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _session.Query<TEntity>();
        }

        public TEntity GetByExpressionFunc(Expression<Func<TEntity, bool>> expression)
        {
            var model = _session.Query<TEntity>().FirstOrDefault(expression);

            _session.Evict(model);

            return model;
        }

        public virtual void Update(TEntity obj)
        {
            if (obj is IEntidadeAuditavel entidadeAuditavel) entidadeAuditavel.DataHoraAlteracao = DateTime.Now;

            _session.Update(obj);
        }

        public void Remove(long id)
        {
            TEntity obj = GetById(id);
            switch (obj)
            {
                case null:
                    return;
                case IEntidadeExcluivel entidadeAuditavel:
                    entidadeAuditavel.DataHoraExclusao = DateTime.Now;
                    break;
                default:
                    _session.Update(obj);
                    break;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}
