using AutoMapper;

namespace Example.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg => { 
                cfg.AddProfiles(typeof(Services.TaxaService).Assembly);
            });
        }
    }
}
