using Survey.Common.Types;
using System;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Survey.Common.Messages
{
    public sealed class AsyncDispatcher
    {
        private readonly IServiceProvider _provider;

        public AsyncDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<Result> Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            var result =await handler.Handle((dynamic)command);
            return result;
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);

            return result;
        }
    }
}
