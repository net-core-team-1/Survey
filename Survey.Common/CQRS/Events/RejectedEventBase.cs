using Survey.Common.Types;
using Survey.Common.Utils.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Survey.Common.CQRS.Events
{
    public abstract class RejectedEventBase<T> : IRejectedEvent<T>
        where T : ICommand
    {
        public IEventKey Key { get; }

        public string Reason { get; }

        public string Code { get; }

        public T Command { get; }

        protected RejectedEventBase() { }
        protected RejectedEventBase(IEventKey key, string reason, string code, T command)
        {
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Reason = reason ?? throw new ArgumentNullException(nameof(reason));
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Command = AnnonymizeSensitiveData(command);
        }

        public abstract IRejectedEvent<T> CreateFrom(string reason, string code, T command);

        public static T AnnonymizeSensitiveData(T command)
        {
            //T instance = (T)Activator.CreateInstance(typeof(T));
            foreach (FieldInfo field in typeof(T).GetFields(BindingFlags.NonPublic| BindingFlags.Instance))
              
                foreach (object attr in field.GetCustomAttributes(true))
                {
                    FieldAnonymizerAttribute authAttr = attr as FieldAnonymizerAttribute;
                    if (authAttr != null)
                        field.SetValue(command, authAttr.anonymizeValue);
                }
            return command;
        }
    }
}
