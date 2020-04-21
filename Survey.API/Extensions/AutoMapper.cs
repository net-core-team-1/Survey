using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Survey.Api.Automapper;

namespace Survey.Api.Utility
{
    public static class AutoMapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TransverseMapper());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
