using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sprawl.Common.Extensibility;

namespace Sprawl.Calendar
{
    public interface ICalendarService : IExtension
    {

        Time Now { get; }

    }
}
