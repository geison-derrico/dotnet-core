using Example.Domain.Interfaces;

namespace Example.Domain.Models
{
    public class Usuario : IUsuario
    {
        public Usuario()
        {

        }

        public Usuario(string login)
        {
            IdOperador = login;
        }

        public string IdOperador { get; }
    }
}