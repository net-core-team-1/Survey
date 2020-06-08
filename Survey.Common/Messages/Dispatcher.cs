using Survey.Common.Types;
using System;
using CSharpFunctionalExtensions;
using System.Threading.Tasks;

namespace Survey.Common.Messages
{
    public sealed class Dispatcher
    {
        private readonly IServiceProvider _provider;

        public Dispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public Result Dispatch(ICommand command)
        {
            Type type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            Type handlerType = type.MakeGenericType(typeArgs);

            dynamic handler = _provider.GetService(handlerType);
            var handlerResult = handler.Handle((dynamic)command);
            if (handlerResult is Result)
                return (Result)handlerResult;
            else if (handlerResult is Task<Result>)
                return ((Task<Result>)handlerResult).Result;
            else return Result.Failure("Insupported handler result type");
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
