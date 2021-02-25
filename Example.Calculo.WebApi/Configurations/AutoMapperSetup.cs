using System;
using AutoMapper;
using Example.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Calculo.WebApi.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project teste das minas
            AutoMapperConfig.RegisterMappings();
        }
    }
}
