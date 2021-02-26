using Microsoft.Extensions.DependencyInjection;
using Example.Domain.Interfaces;

namespace Example.Data.Oracle.Nhibernate.Session
{
    public static class Extensions
    {
        public static IServiceCollection AddNhibernate(this IServiceCollection services, string connectionString)
        {           
            services.AddScoped(s => {
                var scope = s.CreateScope();
                var serviceProvide = scope.ServiceProvider;

                var usuario = serviceProvide.GetService<IUsuario>();

                var sessionFactory = SessionFactoryOracle.CreateSessionFactory(connectionString, usuario);
                return sessionFactory;
            });


            return services;
        }
    }
}
