using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Decorators
{
    public static class ServiceCollectionExtensions
    {
        public static DecoratorBuilder<TInterface> DecoratorFor<TInterface>(this IServiceCollection services)
             where TInterface : class
        {
            return new DecoratorBuilder<TInterface>(services);
        }
    }
}
