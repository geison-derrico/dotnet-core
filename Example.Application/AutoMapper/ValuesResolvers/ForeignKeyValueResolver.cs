using AutoMapper;
using Example.Domain.Interfaces;

namespace Example.Application.AutoMapper.ValuesResolvers
{
    public class ForeignKeyValueResolver<TDestMember> : ForeignKeyValueResolver<object, object, TDestMember>
    {
        public ForeignKeyValueResolver() : base(null)
        {

        }
        public ForeignKeyValueResolver(INHibernateSession session) : base(session)
        {
        }
    }

    public class
        ForeignKeyValueResolver<TSource, TDestination, TDestMember> : IMemberValueResolver<TSource, TDestination, long,
            TDestMember>
    {
        private readonly INHibernateSession _session;

        public ForeignKeyValueResolver(INHibernateSession session)
        {
            _session = session;
        }

        public TDestMember Resolve(TSource source, TDestination destination, long sourceMember, TDestMember destMember,
            ResolutionContext context)
        {
            return _session != null ? _session.Load<TDestMember>(sourceMember) : destMember;
        }
    }
}