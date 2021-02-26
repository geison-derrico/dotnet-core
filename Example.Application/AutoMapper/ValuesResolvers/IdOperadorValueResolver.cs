using AutoMapper;
using Example.Domain.Interfaces;

namespace Example.Application.AutoMapper.ValuesResolvers
{
    public class IdOperadorValueResolver : IdOperadorValueResolver<object, object>
    {
        public IdOperadorValueResolver(IUsuario usuario) : base(usuario)
        {
        }
    }

    public class IdOperadorValueResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, string>
    {
        private readonly IUsuario _usuario;

        public IdOperadorValueResolver(IUsuario usuario)
        {
            _usuario = usuario;
        }

        public string Resolve(TSource source, TDestination destination, string destMember, ResolutionContext context)
        {
            return _usuario.IdOperador;
        }
    }
}