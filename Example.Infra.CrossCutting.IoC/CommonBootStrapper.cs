using System.Reflection;
using Example.Application.Interfaces;
using Example.Application.Services;
using Example.Data.Oracle.Nhibernate;
using Example.Domain.Core.Bus.Denormalize;
using Example.Domain.Core.Bus.Normalize;
using Example.Domain.Core.Notifications;
using Example.Domain.Interfaces;
using Example.Domain.Interfaces.Normalize;
using Example.Domain.Models;
using Example.Infra.CrossCutting.Bus;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Example.Domain.Core.Models.Exception;

namespace Example.Infra.CrossCutting.IoC
{

    public class CommonBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Infra - Bus
            services.AddScoped<IMediatorHandlerNormalize, InMemoryBusNormalize>();
            services.AddScoped<IMediatorHandlerDenormalize, InMemoryBusDenormalize>();

            //Usuario
            services.AddScoped<IUsuario>(serviceProvider =>
            {
                var httpContextAcessor = serviceProvider.GetService<IHttpContextAccessor>();
                string login = httpContextAcessor?.HttpContext?.Request?.Headers["usuario"];

                if (httpContextAcessor?.HttpContext?.Request != null && string.IsNullOrEmpty(login))
                {
                    throw new UsuarioException();
                }

                return new Usuario(login);
            });

            services.AddScoped<INHibernateSession, NHibernateSession>();

            // Application
            services.AddScoped<ITaxaService, TaxaService>();
            services.AddScoped<ICalculoService, CalculoService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Domain - Commands

            services.AddScoped(serviceProder =>
            {
                var session = serviceProder.GetService<NHibernate.ISession>();
                return session.BeginTransaction();
            });

            services.AddScoped(serviceProder =>
            {
                var sessionFactory = serviceProder.GetService<ISessionFactory>();
                return sessionFactory.OpenSession();
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
