using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.CQRS.Events
{
    public interface IEventKey
    {
        string Key { get; }
        string KeyDescription { get; }
    }
}
