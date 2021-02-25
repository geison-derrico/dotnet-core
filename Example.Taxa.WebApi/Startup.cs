using System;
using System.IO;
using System.Reflection;
using Example.Taxa.WebApi.Configurations;
using Example.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Hosting;
using MediatR;
using Example.Domain.CommandHandlers.Normalize;

namespace Example.Taxa.WebApi
{
    public class Startup
    {
        public static ISessionFactory SessionFactory { get; private set; }

        public Startup(IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddWebApi(options =>
            {
                options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
            });

            services.AddAutoMapperSetup();

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Taxa de Juros - Web API",
                    Description = "Retorna a taxa de juros",
                    Contact = new Contact
                    {
                        Name = "Geison Derrico",
                        Url = "https://github.com/geison-derrico/dotnet-core"
                    }
                });

                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                {
                    s.IncludeXmlComments(xmlPath);
                }

            });

            services.AddMediatR(typeof(CommandHandler).Assembly);

            services.AddSingleton(s => SessionFactory);

            RegisterServices(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Taxa Juros API v1.0");
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            CommonBootStrapper.RegisterServices(services);
        }
    }
}
