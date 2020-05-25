using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Common.Messages
{
    public interface IIdentifiable<out T>
    {
        T Id { get; }
    }
}
