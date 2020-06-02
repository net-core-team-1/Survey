using Common.Types.Types.ServiceBus;
using Identity.Api.Services.HandlersDecorators;
using Identity.Api.Services.Users.CommandHandlers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Decorators
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterWithEventsOnHandling<TCommand, TCommandHandler>(this IServiceCollection services)
             where TCommand : ICommand
             where TCommandHandler : class, ICommandHandler<TCommand>
        {
            var builder = new DecoratorBuilder<ICommandHandler<TCommand>>(services);

            builder.Default<TCommandHandler>()
                   .Envelop((provider, createCustomerHandler) =>
                                new PublishEventWhenHandlingDecorator<TCommand>
                                        (createCustomerHandler
                                        , provider.GetService<IRejectedEvent<TCommand>>()
                                        , provider.GetService<IBusPublisher>()))
                .Register();
        }
    }
}
