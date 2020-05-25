using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Survey.Identity.API.Automapper;

namespace Survey.Identity.Extensions
{
    public static class AddSurveyAutoMapper
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
