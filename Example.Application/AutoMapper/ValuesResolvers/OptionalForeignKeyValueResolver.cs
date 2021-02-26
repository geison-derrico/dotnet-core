using Example.Domain.Interfaces;
using AutoMapper;

namespace Example.Application.AutoMapper.ValuesResolvers
{
    public class
        OptionalForeignKeyValueResolver<TOrigem, TDestino, TMembro> : IMemberValueResolver<TOrigem, TDestino, long?,
            TMembro>
        where TMembro : class
    {
        private readonly INHibernateSession _inHibernateSession;

        public OptionalForeignKeyValueResolver(INHibernateSession inHibernateSession)
        {
            _inHibernateSession = inHibernateSession;
        }

        public TMembro Resolve(TOrigem source, TDestino destination, long? sourceMember, TMembro destMember,
            ResolutionContext context)
        {
            if (sourceMember == null)
                return null;
            return _inHibernateSession.Load<TMembro>(sourceMember);
        }
    }
}