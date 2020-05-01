using Common.Types.Types.ServiceBus;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events;
using Identity.Api.Services.Decorators;
using Identity.Api.Services.HandlersDecorators;
using Identity.Api.Services.Users.CommandHandlers;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Extensions.CommandHandlersRegistration
{
    public static class CommandHandlersConfiguration
    {
        public static void RegisterHandlers(this IServiceCollection services)
        {
            services.AddTransient<IRejectedEvent<RegisterUserCommand>, UserRegistrationRejected>();

            services.DecoratorFor<ICommandHandler<RegisterUserCommand>>()
                .Default<RegisterUserCommandHandler>()
                .Envelop((provider, createCustomerHandler) => new RejectedEventOnErrorDecorator<RegisterUserCommand>
                                                                   (createCustomerHandler, provider.GetService<IRejectedEvent<RegisterUserCommand>>(), provider.GetService<IBusPublisher>()))
                .Register();
        }
    }
}
